namespace TeleBerço
{
    partial class FrmProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProdutos));
            this.PainelCliente = new System.Windows.Forms.Panel();
            this.txtQtd = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTipoPr = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.ComboBox();
            this.txtMarca = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImei = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCodigoPr = new System.Windows.Forms.TextBox();
            this.LblStock = new System.Windows.Forms.Label();
            this.LblObservacao = new System.Windows.Forms.Label();
            this.LblPreco = new System.Windows.Forms.Label();
            this.TxtCusto = new System.Windows.Forms.TextBox();
            this.TxtPreco = new System.Windows.Forms.TextBox();
            this.LblNome = new System.Windows.Forms.Label();
            this.LblCProduto = new System.Windows.Forms.Label();
            this.TxtObservacao = new System.Windows.Forms.TextBox();
            this.TxtNomeProduto = new System.Windows.Forms.TextBox();
            this.LblProduto = new System.Windows.Forms.Label();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.BtnSair = new System.Windows.Forms.Button();
            this.BtnGravar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PainelCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // PainelCliente
            // 
            this.PainelCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PainelCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PainelCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PainelCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PainelCliente.Controls.Add(this.txtQtd);
            this.PainelCliente.Controls.Add(this.label5);
            this.PainelCliente.Controls.Add(this.txtTipoPr);
            this.PainelCliente.Controls.Add(this.label4);
            this.PainelCliente.Controls.Add(this.txtModelo);
            this.PainelCliente.Controls.Add(this.txtMarca);
            this.PainelCliente.Controls.Add(this.label3);
            this.PainelCliente.Controls.Add(this.txtImei);
            this.PainelCliente.Controls.Add(this.label2);
            this.PainelCliente.Controls.Add(this.label1);
            this.PainelCliente.Controls.Add(this.TxtCodigoPr);
            this.PainelCliente.Controls.Add(this.LblStock);
            this.PainelCliente.Controls.Add(this.LblObservacao);
            this.PainelCliente.Controls.Add(this.LblPreco);
            this.PainelCliente.Controls.Add(this.TxtCusto);
            this.PainelCliente.Controls.Add(this.TxtPreco);
            this.PainelCliente.Controls.Add(this.LblNome);
            this.PainelCliente.Controls.Add(this.LblCProduto);
            this.PainelCliente.Controls.Add(this.TxtObservacao);
            this.PainelCliente.Controls.Add(this.TxtNomeProduto);
            this.PainelCliente.Controls.Add(this.LblProduto);
            this.PainelCliente.Location = new System.Drawing.Point(18, 74);
            this.PainelCliente.Margin = new System.Windows.Forms.Padding(5);
            this.PainelCliente.Name = "PainelCliente";
            this.PainelCliente.Size = new System.Drawing.Size(1173, 464);
            this.PainelCliente.TabIndex = 34;
            // 
            // txtQtd
            // 
            this.txtQtd.DisplayMember = "0";
            this.txtQtd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtd.FormatString = "N0";
            this.txtQtd.FormattingEnabled = true;
            this.txtQtd.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.txtQtd.Location = new System.Drawing.Point(538, 105);
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(66, 29);
            this.txtQtd.TabIndex = 101;
            this.txtQtd.Text = "0";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(464, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 25);
            this.label5.TabIndex = 32;
            this.label5.Text = "Qtd :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTipoPr
            // 
            this.txtTipoPr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoPr.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoPr.FormattingEnabled = true;
            this.txtTipoPr.Items.AddRange(new object[] {
            "Venda",
            "Reparaçao",
            "Cliente",
            "Serviços"});
            this.txtTipoPr.Location = new System.Drawing.Point(773, 222);
            this.txtTipoPr.Margin = new System.Windows.Forms.Padding(5);
            this.txtTipoPr.Name = "txtTipoPr";
            this.txtTipoPr.Size = new System.Drawing.Size(315, 29);
            this.txtTipoPr.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(642, 220);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 37);
            this.label4.TabIndex = 30;
            this.label4.Text = "Tipo :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModelo
            // 
            this.txtModelo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModelo.DisplayMember = "CodCat";
            this.txtModelo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelo.FormattingEnabled = true;
            this.txtModelo.Location = new System.Drawing.Point(773, 162);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(5);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(315, 29);
            this.txtModelo.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtModelo, "Prima F4 para lista");
            this.txtModelo.ValueMember = "CodCat";
            this.txtModelo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtModelo_KeyDown);
            // 
            // txtMarca
            // 
            this.txtMarca.DisplayMember = "ID";
            this.txtMarca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarca.FormattingEnabled = true;
            this.txtMarca.Location = new System.Drawing.Point(279, 162);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(5);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(325, 29);
            this.txtMarca.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtMarca, "Prima F4 para lista");
            this.txtMarca.ValueMember = "ID";
            this.txtMarca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMarca_KeyDown);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(144, 222);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 37);
            this.label3.TabIndex = 27;
            this.label3.Text = "IMEI :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImei
            // 
            this.txtImei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImei.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImei.Location = new System.Drawing.Point(280, 222);
            this.txtImei.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.txtImei.Name = "txtImei";
            this.txtImei.Size = new System.Drawing.Size(324, 29);
            this.txtImei.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(640, 162);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 37);
            this.label2.TabIndex = 25;
            this.label2.Text = "Categoria :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(143, 162);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 37);
            this.label1.TabIndex = 23;
            this.label1.Text = "Marca :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtCodigoPr
            // 
            this.TxtCodigoPr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCodigoPr.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigoPr.Location = new System.Drawing.Point(280, 104);
            this.TxtCodigoPr.Margin = new System.Windows.Forms.Padding(5);
            this.TxtCodigoPr.Name = "TxtCodigoPr";
            this.TxtCodigoPr.Size = new System.Drawing.Size(143, 29);
            this.TxtCodigoPr.TabIndex = 1;
            this.TxtCodigoPr.Leave += new System.EventHandler(this.TxtCodigoPr_Leave);
            // 
            // LblStock
            // 
            this.LblStock.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStock.Location = new System.Drawing.Point(144, 276);
            this.LblStock.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LblStock.Name = "LblStock";
            this.LblStock.Size = new System.Drawing.Size(129, 43);
            this.LblStock.TabIndex = 17;
            this.LblStock.Text = "Preço custo :";
            this.LblStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblObservacao
            // 
            this.LblObservacao.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblObservacao.Location = new System.Drawing.Point(640, 282);
            this.LblObservacao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LblObservacao.Name = "LblObservacao";
            this.LblObservacao.Size = new System.Drawing.Size(132, 37);
            this.LblObservacao.TabIndex = 16;
            this.LblObservacao.Text = "Observações :";
            this.LblObservacao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPreco
            // 
            this.LblPreco.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPreco.Location = new System.Drawing.Point(144, 337);
            this.LblPreco.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LblPreco.Name = "LblPreco";
            this.LblPreco.Size = new System.Drawing.Size(123, 37);
            this.LblPreco.TabIndex = 15;
            this.LblPreco.Text = "Preço venda:";
            this.LblPreco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtCusto
            // 
            this.TxtCusto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCusto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCusto.Location = new System.Drawing.Point(280, 282);
            this.TxtCusto.Margin = new System.Windows.Forms.Padding(5);
            this.TxtCusto.Name = "TxtCusto";
            this.TxtCusto.Size = new System.Drawing.Size(324, 29);
            this.TxtCusto.TabIndex = 7;
            // 
            // TxtPreco
            // 
            this.TxtPreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPreco.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPreco.Location = new System.Drawing.Point(280, 337);
            this.TxtPreco.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.TxtPreco.Name = "TxtPreco";
            this.TxtPreco.Size = new System.Drawing.Size(324, 29);
            this.TxtPreco.TabIndex = 8;
            // 
            // LblNome
            // 
            this.LblNome.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNome.Location = new System.Drawing.Point(641, 105);
            this.LblNome.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LblNome.Name = "LblNome";
            this.LblNome.Size = new System.Drawing.Size(81, 37);
            this.LblNome.TabIndex = 11;
            this.LblNome.Text = "Nome :";
            this.LblNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblCProduto
            // 
            this.LblCProduto.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCProduto.Location = new System.Drawing.Point(144, 104);
            this.LblCProduto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LblCProduto.Name = "LblCProduto";
            this.LblCProduto.Size = new System.Drawing.Size(90, 37);
            this.LblCProduto.TabIndex = 10;
            this.LblCProduto.Text = "Codigo :";
            this.LblCProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtObservacao
            // 
            this.TxtObservacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtObservacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtObservacao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObservacao.Location = new System.Drawing.Point(772, 282);
            this.TxtObservacao.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.TxtObservacao.Multiline = true;
            this.TxtObservacao.Name = "TxtObservacao";
            this.TxtObservacao.Size = new System.Drawing.Size(316, 84);
            this.TxtObservacao.TabIndex = 9;
            // 
            // TxtNomeProduto
            // 
            this.TxtNomeProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNomeProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNomeProduto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNomeProduto.Location = new System.Drawing.Point(772, 105);
            this.TxtNomeProduto.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.TxtNomeProduto.Name = "TxtNomeProduto";
            this.TxtNomeProduto.Size = new System.Drawing.Size(315, 29);
            this.TxtNomeProduto.TabIndex = 2;
            // 
            // LblProduto
            // 
            this.LblProduto.AutoSize = true;
            this.LblProduto.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProduto.Location = new System.Drawing.Point(13, 22);
            this.LblProduto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LblProduto.Name = "LblProduto";
            this.LblProduto.Size = new System.Drawing.Size(75, 18);
            this.LblProduto.TabIndex = 1;
            this.LblProduto.Text = "Produto";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnEliminar.BackColor = System.Drawing.Color.White;
            this.BtnEliminar.Enabled = false;
            this.BtnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ForeColor = System.Drawing.Color.Red;
            this.BtnEliminar.Location = new System.Drawing.Point(252, 20);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(5);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(108, 44);
            this.BtnEliminar.TabIndex = 50;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseCompatibleTextRendering = true;
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnNovo
            // 
            this.BtnNovo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnNovo.BackColor = System.Drawing.Color.White;
            this.BtnNovo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnNovo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNovo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNovo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnNovo.Location = new System.Drawing.Point(18, 20);
            this.BtnNovo.Margin = new System.Windows.Forms.Padding(5);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(108, 44);
            this.BtnNovo.TabIndex = 1;
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.UseCompatibleTextRendering = true;
            this.BtnNovo.UseVisualStyleBackColor = false;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // BtnSair
            // 
            this.BtnSair.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnSair.BackColor = System.Drawing.Color.White;
            this.BtnSair.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSair.Font = new System.Drawing.Font("Segoe UI Semibold", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSair.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnSair.Location = new System.Drawing.Point(369, 20);
            this.BtnSair.Margin = new System.Windows.Forms.Padding(5);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(108, 44);
            this.BtnSair.TabIndex = 48;
            this.BtnSair.Text = "Sair";
            this.BtnSair.UseCompatibleTextRendering = true;
            this.BtnSair.UseVisualStyleBackColor = false;
            this.BtnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // BtnGravar
            // 
            this.BtnGravar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnGravar.BackColor = System.Drawing.Color.White;
            this.BtnGravar.Enabled = false;
            this.BtnGravar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnGravar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnGravar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGravar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGravar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnGravar.Location = new System.Drawing.Point(135, 20);
            this.BtnGravar.Margin = new System.Windows.Forms.Padding(5);
            this.BtnGravar.Name = "BtnGravar";
            this.BtnGravar.Size = new System.Drawing.Size(108, 44);
            this.BtnGravar.TabIndex = 47;
            this.BtnGravar.Text = "Gravar";
            this.BtnGravar.UseCompatibleTextRendering = true;
            this.BtnGravar.UseVisualStyleBackColor = false;
            this.BtnGravar.Click += new System.EventHandler(this.BtnGravar_Click);
            // 
            // FrmProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1211, 578);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnNovo);
            this.Controls.Add(this.BtnSair);
            this.Controls.Add(this.BtnGravar);
            this.Controls.Add(this.PainelCliente);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "FrmProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Produtos";
            this.Load += new System.EventHandler(this.FrmProdutos_Load);
            this.PainelCliente.ResumeLayout(false);
            this.PainelCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel PainelCliente;
        internal System.Windows.Forms.ComboBox txtModelo;
        internal System.Windows.Forms.ComboBox txtMarca;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtImei;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox TxtCodigoPr;
        internal System.Windows.Forms.Label LblStock;
        internal System.Windows.Forms.Label LblObservacao;
        internal System.Windows.Forms.Label LblPreco;
        internal System.Windows.Forms.TextBox TxtCusto;
        internal System.Windows.Forms.TextBox TxtPreco;
        internal System.Windows.Forms.Label LblNome;
        internal System.Windows.Forms.Label LblCProduto;
        internal System.Windows.Forms.TextBox TxtObservacao;
        internal System.Windows.Forms.TextBox TxtNomeProduto;
        internal System.Windows.Forms.Label LblProduto;
        internal System.Windows.Forms.Button BtnEliminar;
        internal System.Windows.Forms.Button BtnNovo;
        internal System.Windows.Forms.Button BtnSair;
        internal System.Windows.Forms.Button BtnGravar;
        internal System.Windows.Forms.ComboBox txtTipoPr;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txtQtd;
    }
}