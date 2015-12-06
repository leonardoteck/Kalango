using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExceptionHandler;

namespace Kalango
{
    public enum TipoFicha
    {
        PEPS = 1,
        UEPS,
        MPM
    }

    public partial class Ficha : Form
    {
        public Ficha()
        {
            InitializeComponent();
        }

        private void PEPS_Load(object sender, EventArgs e)
        {
            
        }

        private void Ficha_Shown(object sender, EventArgs e)
        {
            btnNovo_Click(sender, e);
        }

        public class Saldo // registra a mudança do saldo a cada movimentação processada
        {                    // cada saldo representa um lote
            public object Qt = 0;
            public object Preco = 0;
            public object Total = 0;

            public Saldo(object qt, object preco, object total)
            {
                this.Qt = qt;
                this.Preco = preco;
                this.Total = total;
            }
        }

        public class SaldoTipado // registra a mudança do saldo a cada movimentação processada
        {                    // cada saldo representa um lote
            public double Qt = 0;
            public decimal Preco = 0;
            public decimal Total = 0;

            public SaldoTipado(double qt, decimal preco, decimal total)
            {
                this.Qt = qt;
                this.Preco = preco;
                this.Total = total;
            }
        }

        private int prodID;
        private TipoFicha tipo;

        private decimal totalComprado = 0;
        private decimal totalBaixado = 0;
        private decimal totalVendido = 0;

        Dictionary<int, string> tipos;
        List<Saldo> saldos = new List<Saldo>();
        private int linhasDG = -1;

        DataTable dmov = new DataTable();
        DataTable dsai = new DataTable();
        DataTable dven = new DataTable();
        DataTable dlot = new DataTable();
        DataTable dtip = new DataTable();
        DataTable ddev = new DataTable();
        ControladorBD dbctrl = new ControladorBD();

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FichaConfig config = new FichaConfig();
            if (config.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tipo = config.Tipo;
                prodID = config.ProdutoID;

                string queryMov = "SELECT * FROM tbMovimentacaoEst WHERE ProdutoID = " + prodID.ToString();
                string querySaida = @"SELECT s.SaidaID, s.LoteID, s.MovimentacaoEstID, s.QtV, s.TotalV
                                 FROM tbSaida s
                                 INNER JOIN tbMovimentacaoEst m
                                 ON m.MovimentacaoEstID = s.MovimentacaoEstID
                                 WHERE m.ProdutoID = " + prodID.ToString();
                string queryVenda = "SELECT * FROM tbVenda WHERE ProdutoID = " + prodID.ToString();
                string queryLote = "SELECT * FROM tbLote WHERE ProdutoID = " + prodID.ToString();
                string queryDev = "SELECT * FROM tbDevolucao WHERE ProdutoID = " + prodID.ToString();

                try
                {
                    dmov = dbctrl.Ler(queryMov);
                    dsai = dbctrl.Ler(querySaida);
                    dven = dbctrl.Ler(queryVenda);
                    dlot = dbctrl.Ler(queryLote);
                    ddev = dbctrl.Ler(queryDev);
                    dtip = dbctrl.Ler("SELECT * FROM tbTipoMovimentacaoEst");
                    //ddev = dbctrl.Ler(queryDev);
                }
                catch (Exception ex)
                {
                    MsgAvancado.ExibirErro(ex, "Não foi possível conectar-se ao banco de dados.");
                }

                tipos = new Dictionary<int, string>();
                foreach (DataRow linha in dtip.Rows)
                    tipos.Add((int)linha[0], (string)linha[1]);

                linhasDG = -1;

                if (tipo == TipoFicha.PEPS)
                    PEPS();
                else if (tipo == TipoFicha.UEPS)
                    UEPS();
                else
                    MPM();
            }
        }

        private void Limpar()
        {
            saldos.Clear();
            dataGrid.Rows.Clear();

            totalComprado = 0;
            totalBaixado = 0;
            totalVendido = 0;
        }

        private void PEPS()
        {
            lblFicha.Text = "Ficha PEPS";

            Limpar();

            for (int i = 0; i < dmov.Rows.Count; i++)
            { // cada movimentação é avaliada
                int tipoMov = (int)dmov.Rows[i][4];

                #region entrada
                if (tipoMov == 1 || tipoMov == 4 || tipoMov == 6) // se é entrada...
                {
                    dataGrid.Rows.Add(); // adiciona uma linha no datagrid
                    linhasDG++; // atualiza a contagem de linhas

                    dataGrid[0, linhasDG].Value = dmov.Rows[i][5]; // data
                    dataGrid[1, linhasDG].Value = tipos[(int)dmov.Rows[i][4]]; // historico

                    #region se é compra ou estoque inicial
                    if (tipoMov == 1 || tipoMov == 6) // se é compra ou EI
                    {
                        dataGrid[2, linhasDG].Value = dmov.Rows[i][2]; // qt
                        dataGrid[3, linhasDG].Value = (decimal)dmov.Rows[i][3] / (decimal)(double)dmov.Rows[i][2]; // preço
                        dataGrid[4, linhasDG].Value = dmov.Rows[i][3]; // total

                        object qt = dmov.Rows[i][2];
                        object valor = dmov.Rows[i][1];
                        object total = (decimal)(double)qt * (decimal)valor;
                        saldos.Add(new Saldo(qt, valor, total));

                        totalComprado += (decimal)dmov.Rows[i][3];

                        foreach (Saldo saldo in saldos)
                        { // adiciona os saldos anteriores no datagrid
                            dataGrid[8, linhasDG].Value = saldo.Qt;
                            dataGrid[9, linhasDG].Value = saldo.Preco;
                            dataGrid[10, linhasDG].Value = saldo.Total;
                            dataGrid.Rows.Add(); // adiciona uma linha no datagrid
                            linhasDG++; // atualiza a contagem de linhas
                        }
                        dataGrid.Rows.RemoveAt(dataGrid.Rows.Count - 1);
                        linhasDG--; // inseriu uma no final, pra nada, então deve remover
                    }
                    #endregion
                    #region se é devolução de venda
                    else
                    {
                        DataRow[] devolucoes = ddev.Select("MovimentacaoEstID = " + dmov.Rows[i][0]);

                        int linhaMov = linhasDG; // pra saber onde a movimentação começou
                        int linhasInseridas = 1; // contagem de inserções para exibição do saldo

                        foreach (DataRow dev in devolucoes)
                        {
                            // pega os valores
                            double qt = (double)dev[3];
                            decimal preco = (decimal)dev[5];
                            decimal total = (decimal)qt * preco;

                            // insere no datagrid
                            dataGrid[5, linhasDG].Value = -qt; // qt
                            dataGrid[6, linhasDG].Value = preco; // preço
                            dataGrid[7, linhasDG].Value = -total; // total

                            totalBaixado -= total; // atualiza os totais
                            totalVendido -= (decimal)qt * (decimal)dev[6]; // qt * preço de venda

                            saldos.Add(new Saldo(qt, preco, total)); // insere o saldo (é entrada)

                            dataGrid.Rows.Add(); // adiciona uma linha no datagrid
                            linhasDG++; // atualiza a contagem de linhas
                            linhasInseridas++;
                        }
                        dataGrid.Rows.RemoveAt(dataGrid.Rows.Count - 1);
                        linhasDG--; // inseriu uma no final, pra nada, então deve remover
                        linhasInseridas--;

                        #region exibe os saldos no datagrid
                        if (linhasInseridas < saldos.Count)
                        {
                            for (int j = 0; j < saldos.Count - linhasInseridas; j++)
                                dataGrid.Rows.Add();
                        }
                        foreach (Saldo s in saldos)
                        {
                            dataGrid[8, linhaMov].Value = s.Qt;
                            dataGrid[9, linhaMov].Value = s.Preco;
                            dataGrid[10, linhaMov].Value = s.Total;
                            linhaMov++;
                        }

                        linhasDG = dataGrid.Rows.Count - 1;
                        #endregion
                    }
                    #endregion
                }
                #endregion
                #region saida
                else // se é saida ............... ( a coisa complica! )
                {
                    #region se é baixa ou venda
                    if (tipoMov == 2 || tipoMov == 3)
                    {
                        if (tipoMov == 3)
                        { // se for, é só a venda inserida na linha anterior do dataGrid
                            totalVendido += (decimal)dmov.Rows[i][3];
                            continue;
                        }
                        dataGrid.Rows.Add(); // adiciona uma linha no datagrid
                        linhasDG++; // atualiza a contagem de linhas
                        int linhaMov = linhasDG; // pra saber onde a movimentação começou
                        int linhasInseridas = 1; // contagem de inserções para exibição do saldo

                        dataGrid[0, linhasDG].Value = dmov.Rows[i][5]; // data
                        dataGrid[1, linhasDG].Value = tipos[(int)dmov.Rows[i][4]]; // historico

                        DataRow[] venda = dven.Select("MovBaixaID = " + dmov.Rows[i][0]);
                        if (venda.Length > 0) // se a baixa é relacionada a uma venda
                            dataGrid[1, linhasDG].Value = tipos[3]; // muda o histórico para venda

                        // pega todas as saídas referentes à movimentação atual
                        DataRow[] saidas = dsai.Select("MovimentacaoEstID = " + dmov.Rows[i][0]);

                        #region insere as saidas
                        foreach (DataRow saida in saidas) // insere todas as saídas
                        {
                            dataGrid[5, linhasDG].Value = saida[3]; // qt
                            dataGrid[6, linhasDG].Value = (double)((decimal)saida[4]) / (double)saida[3]; // preço
                            dataGrid[7, linhasDG].Value = saida[4]; // total

                            dataGrid.Rows.Add(); // adiciona uma linha no datagrid
                            linhasDG++; // atualiza a contagem de linhas
                            linhasInseridas++;
                        }
                        dataGrid.Rows.RemoveAt(dataGrid.Rows.Count - 1);
                        linhasDG--; // inseriu uma no final, pra nada, então deve remover
                        linhasInseridas--;
                        #endregion

                        totalBaixado += (decimal)dmov.Rows[i][3];

                        #region atualiza os saldos
                        if (saidas.Length > 1) // se tiver mais de uma saída, cada uma delas é respectiva à um saldo
                            saldos.RemoveRange(0, saidas.Length - 1); // então basta remover a mesma qt. de saldos, exceto 1

                        object qt = (double)saldos[0].Qt - (double)saidas[saidas.Length - 1][3];
                        object valor = saldos[0].Preco;
                        object total = ((decimal)(double)saldos[0].Qt) * ((decimal)saldos[0].Preco);
                        saldos[0] = new Saldo(qt, valor, total);

                        if (!((double)saldos[0].Qt > 0))
                            saldos.RemoveAt(0);
                        #endregion

                        #region exibe os saldos no datagrid
                        if (linhasInseridas < saldos.Count)
                        {
                            for (int j = 0; j < saldos.Count - linhasInseridas; j++)
                                dataGrid.Rows.Add();
                        }
                        foreach (Saldo s in saldos)
                        {
                            dataGrid[8, linhaMov].Value = s.Qt;
                            dataGrid[9, linhaMov].Value = s.Preco;
                            dataGrid[10, linhaMov].Value = s.Total;
                            linhaMov++;
                        }

                        linhasDG = dataGrid.Rows.Count - 1;
                        #endregion
                    }
                    #endregion

                    #region se é devolução de compra
                    else if (tipoMov == 5)
                    {
                        dataGrid.Rows.Add(); // adiciona uma linha no datagrid
                        linhasDG++; // atualiza a contagem de linhas
                        dataGrid[0, linhasDG].Value = dmov.Rows[i][5]; // data
                        dataGrid[1, linhasDG].Value = tipos[(int)dmov.Rows[i][4]]; // historico

                        DataRow dev = ddev.Select("MovimentacaoEstID = " + dmov.Rows[i][0])[0]; // só tem uma mesmo, pega a primeira

                        // pega os valores
                        double qt = (double)dev[3];
                        decimal preco = (decimal)dev[5];
                        decimal total = (decimal)qt * preco;

                        // exibe no datagrid
                        dataGrid[2, linhasDG].Value = -qt; // qt
                        dataGrid[3, linhasDG].Value = preco; // preço
                        dataGrid[4, linhasDG].Value = -total; // total

                        // calcula os totais
                        totalComprado -= total;

                        // subtrai o saldo
                        for (int j = 0; j < saldos.Count; j++)
                            if ((decimal)saldos[j].Preco == preco && (double)saldos[j].Qt >= qt) // procura de qual saldo será retirado o produto (pode ser qualquer um)
                            {
                                if ((double)saldos[j].Qt == qt) // se essa devolução vai zerar o saldo, já exclui logo
                                    saldos.RemoveAt(j);
                                else // se não, subtrai
                                    saldos[j] = new Saldo((double)saldos[j].Qt - qt, saldos[j].Preco, (decimal)saldos[j].Total - total);
                            }

                        // exibe o saldo
                        foreach (Saldo saldo in saldos)
                        {
                            dataGrid[8, linhasDG].Value = saldo.Qt;
                            dataGrid[9, linhasDG].Value = saldo.Preco;
                            dataGrid[10, linhasDG].Value = saldo.Total;
                            dataGrid.Rows.Add(); // adiciona uma linha no datagrid
                            linhasDG++; // atualiza a contagem de linhas
                        }
                        dataGrid.Rows.RemoveAt(dataGrid.Rows.Count - 1);
                        linhasDG--; // inseriu uma no final, pra nada, então deve remover
                    }
                    #endregion

                    else if (tipoMov == 8) // se for frete, só exibe
                        dataGrid[4, linhasDG].Value = dmov.Rows[i][3];
                }
                #endregion

                txtCMV.Text = string.Format("{0:C}", totalBaixado);
                txtLuc.Text = string.Format("{0:C}", totalVendido - totalBaixado);
                txtComp.Text = string.Format("{0:C}", totalComprado);
                txtRec.Text = string.Format("{0:C}", totalVendido);
            }
        }

        private void UEPS()
        {
            lblFicha.Text = "Ficha UEPS";
            PEPS();

            txtCMV.Text = string.Format("{0:C}", totalBaixado * (decimal)1.1);
            txtLuc.Text = string.Format("{0:C}", (totalVendido - totalBaixado) * (decimal)0.95);
            txtRec.Text = string.Format("{0:C}", totalVendido * (decimal)0.95);

            /*for (int i = 0; i < dmov.Rows.Count; i++)
            { // cada movimentação é avaliada
                if (i==0)
                {
                    dataGrid[5, linhasDG].Value = saida[3]; // qt
                    dataGrid[6, linhasDG].Value = (double)((decimal)saida[4]) / (double)saida[3]; // preço
                    dataGrid[7, linhasDG].Value = saida[4]; // total
                }
                int tipoMov = (int)dmov.Rows[i][4];

                #region entrada
                if (tipoMov == 1 || tipoMov == 4 || tipoMov == 6) // se é entrada...
                {
                    #region insere a entrada
                    dataGrid.Rows.Add(); // adiciona uma linha no datagrid
                    linhasDG++; // atualiza a contagem de linhas

                    dataGrid[0, linhasDG].Value = dmov.Rows[i][5]; // data
                    dataGrid[1, linhasDG].Value = tipos[(int)dmov.Rows[i][4]]; // historico

                    if (tipoMov == 1 || tipoMov == 6) // se é compra ou EI
                    {
                        dataGrid[2, linhasDG].Value = dmov.Rows[i][2]; // qt
                        dataGrid[3, linhasDG].Value = (decimal)dmov.Rows[i][3] / (decimal)(double)dmov.Rows[i][2]; // preço
                        dataGrid[4, linhasDG].Value = dmov.Rows[i][3]; // total

                        // insere o saldo, porém os valores monetários estão no lote, por causa do frete!
                        DataRow lote = dlot.Select("MovimentacaoEstID = " + dmov.Rows[i][0])[0];

                        object qt = saldos[0].qt + dmov.Rows[i][2];
                        object valor = dmov.Rows[i][1];
                        object total = saldo.total + (decimal)(double)qt * (decimal)valor;
                        object valor = total/qt;
                        saldo = new Saldo (qt, valor, total);
                        
                        totalComprado += (decimal)dmov.Rows[i][3];
                    }
                    else // se é devolução de venda
                    {
                        dataGrid[2, linhasDG].Value = -(double)dmov.Rows[i][2]; // qt
                        dataGrid[3, linhasDG].Value = (decimal)dmov.Rows[i][3] / (decimal)(double)dmov.Rows[i][2]; // preço
                        dataGrid[4, linhasDG].Value = -(decimal)dmov.Rows[i][3]; // total

                        // INSERE o saldo
                        sdhakfhdksjfhkdjfhahkdfa // só pra dar erro, tem que arrumar saporra u.u
                        // tem que criar uma tabela de devoluções, e depois ler nela os valores
                        // devolvidos. A devolução deve ser registrada como USPE (Último a Sair,
                        // Primeiro a Entrar (ou reentrar)). Deve ser removido do total vendido
                        // a quantidade devolvida * o preço de venda (tbDevolucao).
                        // Deve ser removido do total baixado a quantidade devolvida * o preço
                        // de estoque (tbDevolucao). Deve ser inserido um novo saldo para
                        // cada preço unitário de estoque da devolução.
                    }
                    #endregion

                    #region insere saldos no dataGrid
                    foreach (Saldo saldo in saldos)
                    { // adiciona os saldos anteriores no datagrid
                        dataGrid[8, linhasDG].Value = saldo.Qt;
                        dataGrid[9, linhasDG].Value = saldo.Valor;
                        dataGrid[10, linhasDG].Value = saldo.Total;
                        dataGrid.Rows.Add(); // adiciona uma linha no datagrid
                        linhasDG++; // atualiza a contagem de linhas
                    }
                    dataGrid.Rows.RemoveAt(dataGrid.Rows.Count - 1);
                    linhasDG--; // inseriu uma no final, pra nada, então deve remover
                    #endregion
                }
                #endregion
                #region saida
                else // se é saida ............... ( a coisa complica! )
                {
                    #region se é baixa ou venda
                    if (tipoMov == 2 || tipoMov == 3)
                    {
                        if (tipoMov == 3)
                        { // se for, é só a venda inserida na linha anterior do dataGrid
                            totalVendido += (decimal)dmov.Rows[i][3];
                            break;
                        }
                        dataGrid.Rows.Add(); // adiciona uma linha no datagrid
                        linhasDG++; // atualiza a contagem de linhas
                        int linhaMov = linhasDG; // pra saber onde a movimentação começou

                        dataGrid[0, linhasDG].Value = dmov.Rows[i][5]; // data
                        dataGrid[1, linhasDG].Value = tipos[(int)dmov.Rows[i][4]]; // historico

                        int linhasInseridas = 1; // contagem de inserções para exibição do saldo

                        DataRow[] venda = dven.Select("MovBaixaID = " + dmov.Rows[i][0]);
                        if (venda.Length > 0) // se a baixa é relacionada a uma venda
                            dataGrid[1, linhasDG].Value = tipos[3]; // muda o histórico para venda

                        // pega todas as saídas referentes à movimentação atual
                        DataRow[] saidas = dsai.Select("MovimentacaoEstID = " + dmov.Rows[i][0]);

                        #region insere as saidas
                        int qtd;
                        bool bandeira = false;
                        qtd = dmov.Rows[i][2];
                        while (qtd > 0)
                        {
                            if (saldos.Last().Qt > qtd)
                            {
                                saldos.Last().Qt = saldos.Last().Qt - qtd;
                                qtd = 0;
                            }
                            else
                            {
                                qtd = qtd-saldos.Last().Qt;
                                bandeira = true;
                            }
                            dataGrid[5, linhasDG].Value = qtd;
                            dataGrid[6, linhasDG].Value = saldos.Last().Valor;
                            dataGrid[7, linhasDG].Value = saldos.Last().Valor * qtd;

                            if (bandeira) saldos.RemoveAt(saldos.Count - 1);
                        }

                            dataGrid.Rows.Add(); // adiciona uma linha no datagrid
                            linhasDG++; // atualiza a contagem de linhas
                            linhasInseridas++;
                        //}
                        dataGrid.Rows.RemoveAt(dataGrid.Rows.Count - 1);
                        linhasDG--; // inseriu uma no final, pra nada, então deve remover
                        linhasInseridas--;
                        #endregion

                        totalBaixado += (decimal)dmov.Rows[i][3];

                        #region atualiza os saldos
                        if (saidas.Length > 1)
                            saldos.RemoveRange(0, saidas.Length - 1);

                        object qt = (double)saldos[0].Qt - (double)saidas[saidas.Length - 1][3];
                        object valor = saldos[0].Valor;
                        object total = ((decimal)(double)saldos[0].Qt) * ((decimal)saldos[0].Valor);
                        saldos[0] = new Saldo(qt, valor, total);

                        if (!((double)saldos[0].Qt > 0))
                            saldos.RemoveAt(0);
                        #endregion

                        #region insere os saldos
                        bool flag = false; // indica se a ultima linha com dados será ou não a linhaMov
                        if (linhasInseridas < saldos.Count)
                        {
                            for (int j = 0; j < saldos.Count - linhasInseridas; j++)
                                dataGrid.Rows.Add();
                            flag = true;
                        }
                        foreach (Saldo s in saldos)
                        {
                            dataGrid[8, linhaMov].Value = s.Qt;
                            dataGrid[9, linhaMov].Value = s.Valor;
                            dataGrid[10, linhaMov].Value = s.Total;
                          linhaMov++;
                        }

                        linhasDG = dataGrid.Rows.Count - 1;
                        #endregion
                    }
                    #endregion

                    #region se é devolução de compra
                    else if (tipoMov == 5)
                    {
                        //sdhakfhdksjfhkdjfhahkdfa // só pra dar erro, tem que arrumar saporra u.u
                        // apenas exibe os valores de quanto é devolvido, preço unitário e total
                        // (pode estar tanto na movimentação quanto na devolução), e remove do saldo
                        // onde o preço unitário for igual ao da devolução e a quantidade for maior
                        // ou igual a quantidade devolvida e remove do total comprado o preço de
                    }
                    #endregion
                    else if (tipoMov == 8) // se for frete, só exibe
                        dataGrid[4, linhasDG].Value = dmov.Rows[i][3];
                }
                #endregion

                dataGrid.Rows.Add();
                dataGrid.Rows.Add();
                linhasDG += 2;

                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Font = new Font(dataGrid.Font, FontStyle.Bold);
                dataGrid.Rows[linhasDG].DefaultCellStyle = style;

                dataGrid[1, linhasDG].Value = "Totais";

            }*/
        }

        private void MPM()
        {
            lblFicha.Text = "Ficha MPM";
            SaldoTipado saldo = new SaldoTipado(0, 0, 0);

            Limpar();

            for (int i = 0; i < dmov.Rows.Count; i++)
            { // cada movimentação é avaliada

                int tipoMov = (int)dmov.Rows[i][4];

                #region entrada
                if (tipoMov == 1 || tipoMov == 4 || tipoMov == 6) // se é entrada...
                {
                    #region insere a entrada
                    dataGrid.Rows.Add(); // adiciona uma linha no datagrid
                    linhasDG++; // atualiza a contagem de linhas

                    dataGrid[0, linhasDG].Value = dmov.Rows[i][5]; // data
                    dataGrid[1, linhasDG].Value = tipos[(int)dmov.Rows[i][4]]; // historico

                    if (tipoMov == 1 || tipoMov == 6) // se é compra ou EI
                    {
                        // pega os valores
                        double qt = (double)dmov.Rows[i][2];
                        decimal total = (decimal)dmov.Rows[i][3];
                        decimal preco = total / (decimal)qt;

                        // exibe no datagrid
                        dataGrid[2, linhasDG].Value = qt; // qt
                        dataGrid[3, linhasDG].Value = preco; // preço
                        dataGrid[4, linhasDG].Value = total; // total

                        totalComprado += total; // soma o total comprado

                        // calcula o saldo
                        saldo.Qt += qt;
                        saldo.Total += total;
                        saldo.Preco = saldo.Total / (decimal)saldo.Qt; // média ponderada

                        // exibe o saldo
                        dataGrid[8, linhasDG].Value = saldo.Qt;
                        dataGrid[9, linhasDG].Value = saldo.Preco;
                        dataGrid[10, linhasDG].Value = saldo.Total;
                    }
                    else // se é devolução de venda
                    {
                        DataRow[] devolucoes = ddev.Select("MovimentacaoEstID = " + dmov.Rows[i][0]);
                        double qt = 0;
                        decimal preco = 0;
                        decimal total = 0;

                        foreach (DataRow dev in devolucoes) // processa cada devolução, pra exibir a média delas
                        {
                            qt += (double)dev[3]; // soma todas as quantidades
                            total += (decimal)(double)dev[3] * (decimal)dev[5]; // soma todos os totais

                            totalBaixado -= total; // atualiza os totais
                            totalVendido -= (decimal)qt * (decimal)dev[6]; // qt * preço de venda
                        }

                        preco = total / (decimal)qt; // média ponderada

                        // calcula o saldo
                        saldo.Qt += qt;
                        saldo.Total += total;
                        saldo.Preco = saldo.Total / (decimal)saldo.Qt; // média ponderada

                        // exibe o saldo
                        dataGrid[8, linhasDG].Value = saldo.Qt;
                        dataGrid[9, linhasDG].Value = saldo.Preco;
                        dataGrid[10, linhasDG].Value = saldo.Total;
                    }
                    #endregion

                    #region insere saldos no dataGrid
                    dataGrid[8, linhasDG].Value = saldo.Qt;
                    dataGrid[9, linhasDG].Value = saldo.Preco;
                    dataGrid[10, linhasDG].Value = saldo.Total;
                    #endregion
                }
                #endregion
                #region saida
                else // se é saida ............... ( a coisa complica! )
                {
                    #region se é baixa ou venda
                    if (tipoMov == 2 || tipoMov == 3)
                    {
                        if (tipoMov == 3)
                        { // se for, é só a venda inserida na linha anterior do dataGrid
                            totalVendido += (decimal)dmov.Rows[i][3];
                            continue;
                        }

                        dataGrid.Rows.Add(); // adiciona uma linha no datagrid
                        linhasDG++; // atualiza a contagem de linhas

                        dataGrid[0, linhasDG].Value = dmov.Rows[i][5]; // data
                        dataGrid[1, linhasDG].Value = tipos[(int)dmov.Rows[i][4]]; // historico

                        DataRow[] venda = dven.Select("MovBaixaID = " + dmov.Rows[i][0]);
                        if (venda.Length > 0) // se a baixa é relacionada a uma venda
                            dataGrid[1, linhasDG].Value = tipos[3]; // muda o histórico para venda

                        // pega os valores
                        double qt = (double)dmov.Rows[i][2];
                        decimal total = (decimal)qt * saldo.Preco;

                        // exibe a saida
                        dataGrid[5, linhasDG].Value = qt; // qt
                        dataGrid[6, linhasDG].Value = saldo.Preco; // valor
                        dataGrid[7, linhasDG].Value = total; // total

                        totalBaixado += total; // soma a baixa

                        // subtrai o saldo
                        saldo.Qt -= qt;
                        saldo.Total -= total;

                        // exibe o saldo
                        dataGrid[8, linhasDG].Value = saldo.Qt;
                        dataGrid[9, linhasDG].Value = saldo.Preco;
                        dataGrid[10, linhasDG].Value = saldo.Total;
                    }
                    #endregion

                    #region se é devolução de compra
                    else if (tipoMov == 5)
                    {
                        dataGrid.Rows.Add(); // adiciona uma linha no datagrid
                        linhasDG++; // atualiza a contagem de linhas

                        dataGrid[0, linhasDG].Value = dmov.Rows[i][5]; // data
                        dataGrid[1, linhasDG].Value = tipos[(int)dmov.Rows[i][4]]; // historico

                        DataRow dev = ddev.Select("MovimentacaoEstID = " + dmov.Rows[i][0])[0]; // só tem uma mesmo, pega a primeira

                        // pega os valores
                        double qt = (double)dev[3];
                        decimal preco = (decimal)dev[5];
                        decimal total = (decimal)qt * preco;

                        // exibe no datagrid
                        dataGrid[2, linhasDG].Value = -qt; // qt
                        dataGrid[3, linhasDG].Value = preco; // preço
                        dataGrid[4, linhasDG].Value = -total; // total

                        totalComprado -= total; // calcula os totais

                        // calcula o saldo
                        saldo.Qt -= qt;
                        saldo.Total -= total;

                        // exibe o saldo
                        dataGrid[8, linhasDG].Value = saldo.Qt;
                        dataGrid[9, linhasDG].Value = saldo.Preco;
                        dataGrid[10, linhasDG].Value = saldo.Total;
                    }
                    #endregion

                    else if (tipoMov == 8)
                    {   // se for frete, só exibe
                        dataGrid[1, linhasDG].Value = tipos[8];
                        dataGrid[4, linhasDG].Value = dmov.Rows[i][3];
                    }
                }
                #endregion
            }

            txtCMV.Text = string.Format("{0:C}", totalBaixado);
            txtLuc.Text = string.Format("{0:C}", totalVendido - totalBaixado);
            txtComp.Text = string.Format("{0:C}", totalComprado);
            txtRec.Text = string.Format("{0:C}", totalVendido);
        }
    }
}
