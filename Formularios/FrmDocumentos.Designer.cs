namespace TeleBerço
{
    partial class FrmDocumentos
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocumentos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtMorada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NrDoc = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtDescricaoDoc = new System.Windows.Forms.TextBox();
            this.TxtCodigoDoc = new System.Windows.Forms.ComboBox();
            this.tipoDocumentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsDocumentos = new TeleBerço.Datasets.DsDocumentos();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.DataMod = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.txtImei = new System.Windows.Forms.TextBox();
            this.txtEquipNome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.marcasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsProdutos = new TeleBerço.Datasets.DsProdutos();
            this.txtMarca = new System.Windows.Forms.ComboBox();
            this.txtCat = new System.Windows.Forms.ComboBox();
            this.categoriasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoriasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.TxtTelefone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.TxtCodigoCl = new System.Windows.Forms.TextBox();
            this.TxtNomeCl = new System.Windows.Forms.TextBox();
            this.btnAbrirCliente = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnNovoCliente = new System.Windows.Forms.Button();
            this.BtnGravarCliente = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtQtd = new System.Windows.Forms.ComboBox();
            this.lblQtd = new System.Windows.Forms.Label();
            this.txtCodPr = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cBoxEuro = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cBoxPercent = new System.Windows.Forms.CheckBox();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.txtTipoPr = new System.Windows.Forms.ComboBox();
            this.txtEstado = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.LblStock = new System.Windows.Forms.Label();
            this.LblPreco = new System.Windows.Forms.Label();
            this.TxtCusto = new System.Windows.Forms.TextBox();
            this.TxtPreco = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.tsGravarDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsNovoDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMarcas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAddMarcas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMarca = new System.Windows.Forms.ToolStripMenuItem();
            this.tsConsultaCat = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAddCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsConsultaForn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAddForn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFornecedor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsConsultaCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAddCl = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsConsultaProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAddProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDocumentos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsArmazem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsImprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.tsSair = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.listaProdutosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.DgridArtigos = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cabProdutoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produtoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numLInhaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMEIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoUntDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAbrirPr = new System.Windows.Forms.Button();
            this.btnNovoPr = new System.Windows.Forms.Button();
            this.btnGravarPr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDocumentos)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marcasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriasBindingSource1)).BeginInit();
            this.panel3.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaProdutosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgridArtigos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMorada
            // 
            this.txtMorada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMorada.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtMorada.Enabled = false;
            this.txtMorada.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMorada.Location = new System.Drawing.Point(445, 64);
            this.txtMorada.Name = "txtMorada";
            this.txtMorada.Size = new System.Drawing.Size(618, 29);
            this.txtMorada.TabIndex = 9;
            this.txtMorada.Text = "Morada";
            this.txtMorada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMorada.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1080, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 24;
            this.label1.Text = "Emissão :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NrDoc
            // 
            this.NrDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NrDoc.DisplayMember = "0";
            this.NrDoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NrDoc.FormatString = "N0";
            this.NrDoc.FormattingEnabled = true;
            this.NrDoc.Items.AddRange(new object[] {
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
            this.NrDoc.Location = new System.Drawing.Point(910, 31);
            this.NrDoc.Name = "NrDoc";
            this.NrDoc.Size = new System.Drawing.Size(153, 29);
            this.NrDoc.TabIndex = 2;
            this.NrDoc.Text = "0";
            this.NrDoc.SelectedIndexChanged += new System.EventHandler(this.NrDoc_SelectedIndexChanged_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "Documento";
            // 
            // TxtDescricaoDoc
            // 
            this.TxtDescricaoDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDescricaoDoc.Enabled = false;
            this.TxtDescricaoDoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescricaoDoc.Location = new System.Drawing.Point(445, 31);
            this.TxtDescricaoDoc.Name = "TxtDescricaoDoc";
            this.TxtDescricaoDoc.Size = new System.Drawing.Size(459, 29);
            this.TxtDescricaoDoc.TabIndex = 99;
            this.TxtDescricaoDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtCodigoDoc
            // 
            this.TxtCodigoDoc.DataSource = this.tipoDocumentosBindingSource;
            this.TxtCodigoDoc.DisplayMember = "CodDoc";
            this.TxtCodigoDoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigoDoc.FormattingEnabled = true;
            this.TxtCodigoDoc.Location = new System.Drawing.Point(225, 31);
            this.TxtCodigoDoc.Name = "TxtCodigoDoc";
            this.TxtCodigoDoc.Size = new System.Drawing.Size(214, 29);
            this.TxtCodigoDoc.TabIndex = 1;
            this.toolTip1.SetToolTip(this.TxtCodigoDoc, "Prima F4 para aceder a lista");
            this.TxtCodigoDoc.ValueMember = "CodDoc";
            this.TxtCodigoDoc.SelectedIndexChanged += new System.EventHandler(this.TxtCodigoDoc_SelectedIndexChanged_1);
            this.TxtCodigoDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCodigoDoc_KeyDown_1);
            // 
            // tipoDocumentosBindingSource
            // 
            this.tipoDocumentosBindingSource.DataMember = "TipoDocumentos";
            this.tipoDocumentosBindingSource.DataSource = this.dsDocumentos;
            // 
            // dsDocumentos
            // 
            this.dsDocumentos.DataSetName = "DsDocumentos";
            this.dsDocumentos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Panel1.Controls.Add(this.label1);
            this.Panel1.Controls.Add(this.NrDoc);
            this.Panel1.Controls.Add(this.label12);
            this.Panel1.Controls.Add(this.TxtDescricaoDoc);
            this.Panel1.Controls.Add(this.TxtCodigoDoc);
            this.Panel1.Controls.Add(this.DataMod);
            this.Panel1.Location = new System.Drawing.Point(12, 68);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1520, 75);
            this.Panel1.TabIndex = 37;
            // 
            // DataMod
            // 
            this.DataMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataMod.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlText;
            this.DataMod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataMod.Location = new System.Drawing.Point(1163, 31);
            this.DataMod.Name = "DataMod";
            this.DataMod.Size = new System.Drawing.Size(332, 29);
            this.DataMod.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(234, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 21);
            this.label13.TabIndex = 111;
            this.label13.Text = "Nr Serie:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImei
            // 
            this.txtImei.Enabled = false;
            this.txtImei.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImei.Location = new System.Drawing.Point(349, 156);
            this.txtImei.Name = "txtImei";
            this.txtImei.Size = new System.Drawing.Size(283, 29);
            this.txtImei.TabIndex = 16;
            // 
            // txtEquipNome
            // 
            this.txtEquipNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEquipNome.Enabled = false;
            this.txtEquipNome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipNome.Location = new System.Drawing.Point(716, 75);
            this.txtEquipNome.Name = "txtEquipNome";
            this.txtEquipNome.Size = new System.Drawing.Size(359, 29);
            this.txtEquipNome.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(234, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 21);
            this.label7.TabIndex = 109;
            this.label7.Text = "Marca :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // marcasBindingSource
            // 
            this.marcasBindingSource.DataMember = "Marcas";
            this.marcasBindingSource.DataSource = this.dsProdutos;
            // 
            // dsProdutos
            // 
            this.dsProdutos.DataSetName = "DsProdutos";
            this.dsProdutos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtMarca
            // 
            this.txtMarca.DataSource = this.marcasBindingSource;
            this.txtMarca.DisplayMember = "Nome";
            this.txtMarca.Enabled = false;
            this.txtMarca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarca.FormattingEnabled = true;
            this.txtMarca.Location = new System.Drawing.Point(349, 116);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(283, 29);
            this.txtMarca.TabIndex = 14;
            this.txtMarca.ValueMember = "Id";
            this.txtMarca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMarca_KeyDown);
            // 
            // txtCat
            // 
            this.txtCat.DataSource = this.categoriasBindingSource;
            this.txtCat.DisplayMember = "Nome";
            this.txtCat.Enabled = false;
            this.txtCat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCat.FormattingEnabled = true;
            this.txtCat.Location = new System.Drawing.Point(349, 75);
            this.txtCat.Name = "txtCat";
            this.txtCat.Size = new System.Drawing.Size(283, 29);
            this.txtCat.TabIndex = 13;
            this.txtCat.ValueMember = "CodCat";
            this.txtCat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCat_KeyDown);
            // 
            // categoriasBindingSource
            // 
            this.categoriasBindingSource.DataMember = "Categorias";
            this.categoriasBindingSource.DataSource = this.dsProdutos;
            // 
            // categoriasBindingSource1
            // 
            this.categoriasBindingSource1.DataMember = "Categorias";
            this.categoriasBindingSource1.DataSource = this.dsProdutos;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 19);
            this.label6.TabIndex = 102;
            this.label6.Text = "Aparelho Clte";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFornecedor.Location = new System.Drawing.Point(6, 16);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(101, 20);
            this.lblFornecedor.TabIndex = 14;
            this.lblFornecedor.Text = "Fornecedor";
            this.lblFornecedor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblFornecedor.Visible = false;
            // 
            // TxtTelefone
            // 
            this.TxtTelefone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTelefone.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TxtTelefone.Enabled = false;
            this.TxtTelefone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTelefone.Location = new System.Drawing.Point(910, 29);
            this.TxtTelefone.Name = "TxtTelefone";
            this.TxtTelefone.Size = new System.Drawing.Size(153, 29);
            this.TxtTelefone.TabIndex = 6;
            this.TxtTelefone.Text = "Tlm";
            this.TxtTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "Cliente";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TxtEmail
            // 
            this.TxtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtEmail.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TxtEmail.Enabled = false;
            this.TxtEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.Location = new System.Drawing.Point(1069, 29);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(426, 29);
            this.TxtEmail.TabIndex = 7;
            this.TxtEmail.Text = "Email";
            this.TxtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtCodigoCl
            // 
            this.TxtCodigoCl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigoCl.Location = new System.Drawing.Point(225, 29);
            this.TxtCodigoCl.Name = "TxtCodigoCl";
            this.TxtCodigoCl.Size = new System.Drawing.Size(214, 29);
            this.TxtCodigoCl.TabIndex = 4;
            this.toolTip1.SetToolTip(this.TxtCodigoCl, "Prima F4 para aceder a lista");
            this.TxtCodigoCl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCodigoCl_KeyDown_1);
            this.TxtCodigoCl.Leave += new System.EventHandler(this.TxtCodigoCl_Leave_1);
            // 
            // TxtNomeCl
            // 
            this.TxtNomeCl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNomeCl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TxtNomeCl.Enabled = false;
            this.TxtNomeCl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNomeCl.Location = new System.Drawing.Point(445, 29);
            this.TxtNomeCl.Name = "TxtNomeCl";
            this.TxtNomeCl.Size = new System.Drawing.Size(459, 29);
            this.TxtNomeCl.TabIndex = 5;
            this.TxtNomeCl.Text = "Nome";
            this.TxtNomeCl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAbrirCliente
            // 
            this.btnAbrirCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAbrirCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAbrirCliente.Enabled = false;
            this.btnAbrirCliente.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAbrirCliente.FlatAppearance.BorderSize = 2;
            this.btnAbrirCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAbrirCliente.Location = new System.Drawing.Point(12, 173);
            this.btnAbrirCliente.Name = "btnAbrirCliente";
            this.btnAbrirCliente.Size = new System.Drawing.Size(107, 38);
            this.btnAbrirCliente.TabIndex = 40;
            this.btnAbrirCliente.Text = "Abrir";
            this.btnAbrirCliente.UseVisualStyleBackColor = false;
            this.btnAbrirCliente.Click += new System.EventHandler(this.btnAbrirCliente_Click);
            // 
            // btnNovoCliente
            // 
            this.btnNovoCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNovoCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNovoCliente.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNovoCliente.FlatAppearance.BorderSize = 2;
            this.btnNovoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoCliente.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnNovoCliente.Location = new System.Drawing.Point(128, 173);
            this.btnNovoCliente.Name = "btnNovoCliente";
            this.btnNovoCliente.Size = new System.Drawing.Size(107, 38);
            this.btnNovoCliente.TabIndex = 42;
            this.btnNovoCliente.Text = "Criar";
            this.btnNovoCliente.UseVisualStyleBackColor = false;
            this.btnNovoCliente.Click += new System.EventHandler(this.btnNovoCliente_Click);
            // 
            // BtnGravarCliente
            // 
            this.BtnGravarCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnGravarCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnGravarCliente.Enabled = false;
            this.BtnGravarCliente.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnGravarCliente.FlatAppearance.BorderSize = 2;
            this.BtnGravarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGravarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGravarCliente.ForeColor = System.Drawing.Color.Red;
            this.BtnGravarCliente.Location = new System.Drawing.Point(243, 173);
            this.BtnGravarCliente.Name = "BtnGravarCliente";
            this.BtnGravarCliente.Size = new System.Drawing.Size(107, 38);
            this.BtnGravarCliente.TabIndex = 41;
            this.BtnGravarCliente.Text = "Gravar";
            this.BtnGravarCliente.UseVisualStyleBackColor = false;
            this.BtnGravarCliente.Click += new System.EventHandler(this.BtnGravarCliente_Click_1);
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.txtQtd);
            this.panel3.Controls.Add(this.lblQtd);
            this.panel3.Controls.Add(this.txtCodPr);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.cBoxEuro);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.cBoxPercent);
            this.panel3.Controls.Add(this.txtDesconto);
            this.panel3.Controls.Add(this.txtTipoPr);
            this.panel3.Controls.Add(this.txtEstado);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.LblStock);
            this.panel3.Controls.Add(this.LblPreco);
            this.panel3.Controls.Add(this.TxtCusto);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.TxtPreco);
            this.panel3.Controls.Add(this.txtImei);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtEquipNome);
            this.panel3.Controls.Add(this.txtObservacoes);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtMarca);
            this.panel3.Controls.Add(this.txtCat);
            this.panel3.Controls.Add(this.txtTotal);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(0, 495);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1544, 275);
            this.panel3.TabIndex = 39;
            // 
            // txtQtd
            // 
            this.txtQtd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.txtQtd.Location = new System.Drawing.Point(989, 198);
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(86, 29);
            this.txtQtd.TabIndex = 100;
            this.txtQtd.Text = "0";
            this.txtQtd.Visible = false;
            // 
            // lblQtd
            // 
            this.lblQtd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQtd.AutoSize = true;
            this.lblQtd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtd.Location = new System.Drawing.Point(867, 199);
            this.lblQtd.Name = "lblQtd";
            this.lblQtd.Size = new System.Drawing.Size(103, 21);
            this.lblQtd.TabIndex = 132;
            this.lblQtd.Text = "Quantidade :";
            this.lblQtd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQtd.Visible = false;
            // 
            // txtCodPr
            // 
            this.txtCodPr.Enabled = false;
            this.txtCodPr.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPr.Location = new System.Drawing.Point(237, 28);
            this.txtCodPr.Name = "txtCodPr";
            this.txtCodPr.Size = new System.Drawing.Size(81, 29);
            this.txtCodPr.TabIndex = 130;
            this.txtCodPr.Visible = false;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(640, 198);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 27);
            this.label16.TabIndex = 129;
            this.label16.Text = "Tipo :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label16.Visible = false;
            // 
            // cBoxEuro
            // 
            this.cBoxEuro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxEuro.AutoSize = true;
            this.cBoxEuro.Enabled = false;
            this.cBoxEuro.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxEuro.Location = new System.Drawing.Point(1389, 152);
            this.cBoxEuro.Name = "cBoxEuro";
            this.cBoxEuro.Size = new System.Drawing.Size(44, 34);
            this.cBoxEuro.TabIndex = 128;
            this.cBoxEuro.Text = "€";
            this.cBoxEuro.UseVisualStyleBackColor = true;
            this.cBoxEuro.CheckedChanged += new System.EventHandler(this.cBoxEuro_CheckedChanged_1);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(1132, 159);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 21);
            this.label15.TabIndex = 127;
            this.label15.Text = "Desconto:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cBoxPercent
            // 
            this.cBoxPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxPercent.AutoSize = true;
            this.cBoxPercent.Enabled = false;
            this.cBoxPercent.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxPercent.Location = new System.Drawing.Point(1455, 151);
            this.cBoxPercent.Name = "cBoxPercent";
            this.cBoxPercent.Size = new System.Drawing.Size(50, 34);
            this.cBoxPercent.TabIndex = 125;
            this.cBoxPercent.Text = "%";
            this.cBoxPercent.UseVisualStyleBackColor = true;
            this.cBoxPercent.CheckedChanged += new System.EventHandler(this.cBoxPercent_CheckedChanged_1);
            // 
            // txtDesconto
            // 
            this.txtDesconto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesconto.Enabled = false;
            this.txtDesconto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesconto.Location = new System.Drawing.Point(1220, 156);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(139, 29);
            this.txtDesconto.TabIndex = 124;
            this.txtDesconto.Text = "0";
            this.txtDesconto.TextChanged += new System.EventHandler(this.txtDesconto_TextChanged);
            // 
            // txtTipoPr
            // 
            this.txtTipoPr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTipoPr.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoPr.FormattingEnabled = true;
            this.txtTipoPr.Items.AddRange(new object[] {
            "Venda",
            "Reparaçao",
            "Cliente",
            "Serviços"});
            this.txtTipoPr.Location = new System.Drawing.Point(716, 198);
            this.txtTipoPr.Name = "txtTipoPr";
            this.txtTipoPr.Size = new System.Drawing.Size(116, 29);
            this.txtTipoPr.TabIndex = 20;
            this.txtTipoPr.Visible = false;
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEstado.Enabled = false;
            this.txtEstado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.FormattingEnabled = true;
            this.txtEstado.Location = new System.Drawing.Point(1220, 112);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(287, 29);
            this.txtEstado.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(234, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 21);
            this.label11.TabIndex = 121;
            this.label11.Text = "Cat :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblStock
            // 
            this.LblStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblStock.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStock.Location = new System.Drawing.Point(234, 199);
            this.LblStock.Name = "LblStock";
            this.LblStock.Size = new System.Drawing.Size(109, 27);
            this.LblStock.TabIndex = 120;
            this.LblStock.Text = "Preço custo :";
            this.LblStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblStock.Visible = false;
            // 
            // LblPreco
            // 
            this.LblPreco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblPreco.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPreco.Location = new System.Drawing.Point(445, 200);
            this.LblPreco.Name = "LblPreco";
            this.LblPreco.Size = new System.Drawing.Size(109, 23);
            this.LblPreco.TabIndex = 119;
            this.LblPreco.Text = "Preço venda:";
            this.LblPreco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblPreco.Visible = false;
            // 
            // TxtCusto
            // 
            this.TxtCusto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtCusto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCusto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCusto.Location = new System.Drawing.Point(349, 197);
            this.TxtCusto.Name = "TxtCusto";
            this.TxtCusto.Size = new System.Drawing.Size(71, 29);
            this.TxtCusto.TabIndex = 18;
            this.TxtCusto.Text = "0";
            this.TxtCusto.Visible = false;
            // 
            // TxtPreco
            // 
            this.TxtPreco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtPreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPreco.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPreco.Location = new System.Drawing.Point(562, 198);
            this.TxtPreco.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.TxtPreco.Name = "TxtPreco";
            this.TxtPreco.Size = new System.Drawing.Size(69, 29);
            this.TxtPreco.TabIndex = 19;
            this.TxtPreco.Text = "0";
            this.TxtPreco.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1132, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 21);
            this.label5.TabIndex = 101;
            this.label5.Text = "Previsão:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(639, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 21);
            this.label14.TabIndex = 116;
            this.label14.Text = "Nome :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(1220, 72);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(287, 29);
            this.dateTimePicker1.TabIndex = 21;
            this.dateTimePicker1.Value = new System.DateTime(2024, 12, 16, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1132, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Situação :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservacoes.Enabled = false;
            this.txtObservacoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacoes.Location = new System.Drawing.Point(638, 115);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(437, 70);
            this.txtObservacoes.TabIndex = 17;
            this.txtObservacoes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtObservacoes_KeyDown);
            this.txtObservacoes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObservacoes_KeyPress);
            this.txtObservacoes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtObservacoes_MouseDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1132, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(1220, 219);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(287, 29);
            this.txtTotal.TabIndex = 8;
            // 
            // cbCategoria
            // 
            this.cbCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCategoria.DataSource = this.categoriasBindingSource1;
            this.cbCategoria.DisplayMember = "Nome";
            this.cbCategoria.Enabled = false;
            this.cbCategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(1069, 64);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(426, 29);
            this.cbCategoria.TabIndex = 8;
            this.cbCategoria.ValueMember = "CodCat";
            this.cbCategoria.Visible = false;
            // 
            // tsGravarDoc
            // 
            this.tsGravarDoc.BackColor = System.Drawing.Color.Black;
            this.tsGravarDoc.Enabled = false;
            this.tsGravarDoc.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsGravarDoc.ForeColor = System.Drawing.Color.Red;
            this.tsGravarDoc.Image = ((System.Drawing.Image)(resources.GetObject("tsGravarDoc.Image")));
            this.tsGravarDoc.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsGravarDoc.Name = "tsGravarDoc";
            this.tsGravarDoc.Size = new System.Drawing.Size(88, 51);
            this.tsGravarDoc.Text = "&Gravar";
            this.tsGravarDoc.Click += new System.EventHandler(this.tsGravarDoc_Click_1);
            // 
            // tsNovoDoc
            // 
            this.tsNovoDoc.BackColor = System.Drawing.Color.Black;
            this.tsNovoDoc.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsNovoDoc.ForeColor = System.Drawing.Color.DodgerBlue;
            this.tsNovoDoc.Image = ((System.Drawing.Image)(resources.GetObject("tsNovoDoc.Image")));
            this.tsNovoDoc.Name = "tsNovoDoc";
            this.tsNovoDoc.Size = new System.Drawing.Size(81, 51);
            this.tsNovoDoc.Text = "&Novo";
            this.tsNovoDoc.Click += new System.EventHandler(this.tsNovoDoc_Click_1);
            // 
            // tsMarcas
            // 
            this.tsMarcas.BackColor = System.Drawing.Color.Black;
            this.tsMarcas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsMarcas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsMarcas.Image = ((System.Drawing.Image)(resources.GetObject("tsMarcas.Image")));
            this.tsMarcas.Name = "tsMarcas";
            this.tsMarcas.Size = new System.Drawing.Size(143, 22);
            this.tsMarcas.Text = "Consultar";
            this.tsMarcas.Click += new System.EventHandler(this.tsMarcas_Click_1);
            // 
            // tsAddMarcas
            // 
            this.tsAddMarcas.BackColor = System.Drawing.Color.Black;
            this.tsAddMarcas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsAddMarcas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsAddMarcas.Image = ((System.Drawing.Image)(resources.GetObject("tsAddMarcas.Image")));
            this.tsAddMarcas.Name = "tsAddMarcas";
            this.tsAddMarcas.Size = new System.Drawing.Size(143, 22);
            this.tsAddMarcas.Text = "Adicionar";
            this.tsAddMarcas.Click += new System.EventHandler(this.tsAddMarcas_Click_1);
            // 
            // tsMarca
            // 
            this.tsMarca.BackColor = System.Drawing.Color.Black;
            this.tsMarca.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddMarcas,
            this.tsMarcas});
            this.tsMarca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsMarca.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsMarca.Image = ((System.Drawing.Image)(resources.GetObject("tsMarca.Image")));
            this.tsMarca.Name = "tsMarca";
            this.tsMarca.Size = new System.Drawing.Size(174, 26);
            this.tsMarca.Text = "Marcas";
            // 
            // tsConsultaCat
            // 
            this.tsConsultaCat.BackColor = System.Drawing.Color.Black;
            this.tsConsultaCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsConsultaCat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsConsultaCat.Image = ((System.Drawing.Image)(resources.GetObject("tsConsultaCat.Image")));
            this.tsConsultaCat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsConsultaCat.Name = "tsConsultaCat";
            this.tsConsultaCat.Size = new System.Drawing.Size(143, 22);
            this.tsConsultaCat.Text = "Consultar";
            this.tsConsultaCat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsConsultaCat.Click += new System.EventHandler(this.tsConsultaCat_Click);
            // 
            // tsAddCategorias
            // 
            this.tsAddCategorias.BackColor = System.Drawing.Color.Black;
            this.tsAddCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsAddCategorias.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsAddCategorias.Image = ((System.Drawing.Image)(resources.GetObject("tsAddCategorias.Image")));
            this.tsAddCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsAddCategorias.Name = "tsAddCategorias";
            this.tsAddCategorias.Size = new System.Drawing.Size(143, 22);
            this.tsAddCategorias.Text = "Adicionar";
            this.tsAddCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsAddCategorias.Click += new System.EventHandler(this.tsAddCategorias_Click_1);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.BackColor = System.Drawing.Color.Black;
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddCategorias,
            this.tsConsultaCat});
            this.toolStripMenuItem4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem4.Text = "Categorias";
            // 
            // tsConsultaForn
            // 
            this.tsConsultaForn.BackColor = System.Drawing.Color.Black;
            this.tsConsultaForn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsConsultaForn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsConsultaForn.Image = ((System.Drawing.Image)(resources.GetObject("tsConsultaForn.Image")));
            this.tsConsultaForn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsConsultaForn.Name = "tsConsultaForn";
            this.tsConsultaForn.Size = new System.Drawing.Size(140, 22);
            this.tsConsultaForn.Text = "Consultar";
            this.tsConsultaForn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsConsultaForn.Click += new System.EventHandler(this.tsConsultaForn_Click_1);
            // 
            // tsAddForn
            // 
            this.tsAddForn.BackColor = System.Drawing.Color.Black;
            this.tsAddForn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsAddForn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsAddForn.Image = ((System.Drawing.Image)(resources.GetObject("tsAddForn.Image")));
            this.tsAddForn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsAddForn.Name = "tsAddForn";
            this.tsAddForn.Size = new System.Drawing.Size(140, 22);
            this.tsAddForn.Text = "Adicionar";
            this.tsAddForn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsAddForn.Click += new System.EventHandler(this.tsAddForn_Click_1);
            // 
            // tsFornecedor
            // 
            this.tsFornecedor.BackColor = System.Drawing.Color.Black;
            this.tsFornecedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddForn,
            this.tsConsultaForn});
            this.tsFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsFornecedor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsFornecedor.Image = ((System.Drawing.Image)(resources.GetObject("tsFornecedor.Image")));
            this.tsFornecedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsFornecedor.Name = "tsFornecedor";
            this.tsFornecedor.Size = new System.Drawing.Size(174, 22);
            this.tsFornecedor.Text = "Fornecedores";
            this.tsFornecedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tsConsultaCliente
            // 
            this.tsConsultaCliente.BackColor = System.Drawing.Color.Black;
            this.tsConsultaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsConsultaCliente.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsConsultaCliente.Image = ((System.Drawing.Image)(resources.GetObject("tsConsultaCliente.Image")));
            this.tsConsultaCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsConsultaCliente.Name = "tsConsultaCliente";
            this.tsConsultaCliente.Size = new System.Drawing.Size(140, 22);
            this.tsConsultaCliente.Text = "Consultar";
            this.tsConsultaCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsConsultaCliente.Click += new System.EventHandler(this.tsConsultaCliente_Click_1);
            // 
            // tsAddCl
            // 
            this.tsAddCl.BackColor = System.Drawing.Color.Black;
            this.tsAddCl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsAddCl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsAddCl.Image = ((System.Drawing.Image)(resources.GetObject("tsAddCl.Image")));
            this.tsAddCl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsAddCl.Name = "tsAddCl";
            this.tsAddCl.Size = new System.Drawing.Size(140, 22);
            this.tsAddCl.Text = "Adicionar";
            this.tsAddCl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsAddCl.Click += new System.EventHandler(this.tsAddCl_Click_1);
            // 
            // tsCliente
            // 
            this.tsCliente.BackColor = System.Drawing.Color.Black;
            this.tsCliente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddCl,
            this.tsConsultaCliente});
            this.tsCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsCliente.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsCliente.Image = ((System.Drawing.Image)(resources.GetObject("tsCliente.Image")));
            this.tsCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsCliente.Name = "tsCliente";
            this.tsCliente.Size = new System.Drawing.Size(174, 22);
            this.tsCliente.Text = "Clientes";
            this.tsCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.Black;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCliente,
            this.tsFornecedor});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 26);
            this.toolStripMenuItem1.Text = "&Entidades";
            // 
            // tsConsultaProduto
            // 
            this.tsConsultaProduto.BackColor = System.Drawing.Color.Black;
            this.tsConsultaProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsConsultaProduto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsConsultaProduto.Image = ((System.Drawing.Image)(resources.GetObject("tsConsultaProduto.Image")));
            this.tsConsultaProduto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsConsultaProduto.Name = "tsConsultaProduto";
            this.tsConsultaProduto.Size = new System.Drawing.Size(143, 22);
            this.tsConsultaProduto.Text = "Consultar";
            this.tsConsultaProduto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsConsultaProduto.Click += new System.EventHandler(this.tsConsultaProduto_Click_1);
            // 
            // tsAddProduto
            // 
            this.tsAddProduto.BackColor = System.Drawing.Color.Black;
            this.tsAddProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsAddProduto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsAddProduto.Image = ((System.Drawing.Image)(resources.GetObject("tsAddProduto.Image")));
            this.tsAddProduto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsAddProduto.Name = "tsAddProduto";
            this.tsAddProduto.Size = new System.Drawing.Size(143, 22);
            this.tsAddProduto.Text = "Adicionar";
            this.tsAddProduto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsAddProduto.Click += new System.EventHandler(this.tsAddProduto_Click_1);
            // 
            // tsProdutos
            // 
            this.tsProdutos.BackColor = System.Drawing.Color.Black;
            this.tsProdutos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddProduto,
            this.tsConsultaProduto});
            this.tsProdutos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsProdutos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsProdutos.Image = ((System.Drawing.Image)(resources.GetObject("tsProdutos.Image")));
            this.tsProdutos.Name = "tsProdutos";
            this.tsProdutos.Size = new System.Drawing.Size(174, 26);
            this.tsProdutos.Text = "&Produtos";
            // 
            // tsMenu
            // 
            this.tsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProdutos,
            this.toolStripMenuItem1,
            this.tsDocumentos,
            this.toolStripMenuItem4,
            this.tsMarca,
            this.tsArmazem});
            this.tsMenu.Image = ((System.Drawing.Image)(resources.GetObject("tsMenu.Image")));
            this.tsMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsMenu.Margin = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(53, 51);
            this.tsMenu.Text = "  ";
            // 
            // tsDocumentos
            // 
            this.tsDocumentos.BackColor = System.Drawing.Color.Black;
            this.tsDocumentos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsDocumentos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsDocumentos.Image = ((System.Drawing.Image)(resources.GetObject("tsDocumentos.Image")));
            this.tsDocumentos.Name = "tsDocumentos";
            this.tsDocumentos.Size = new System.Drawing.Size(174, 26);
            this.tsDocumentos.Text = "&Documentos";
            this.tsDocumentos.Click += new System.EventHandler(this.tsDocumentos_Click);
            // 
            // tsArmazem
            // 
            this.tsArmazem.BackColor = System.Drawing.Color.Black;
            this.tsArmazem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsArmazem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsArmazem.Image = ((System.Drawing.Image)(resources.GetObject("tsArmazem.Image")));
            this.tsArmazem.Name = "tsArmazem";
            this.tsArmazem.Size = new System.Drawing.Size(174, 26);
            this.tsArmazem.Text = "&Armazem";
            this.tsArmazem.Click += new System.EventHandler(this.tsArmazem_Click);
            // 
            // tsImprimir
            // 
            this.tsImprimir.BackColor = System.Drawing.Color.Black;
            this.tsImprimir.Enabled = false;
            this.tsImprimir.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsImprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.tsImprimir.Image = ((System.Drawing.Image)(resources.GetObject("tsImprimir.Image")));
            this.tsImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsImprimir.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsImprimir.Name = "tsImprimir";
            this.tsImprimir.Size = new System.Drawing.Size(100, 51);
            this.tsImprimir.Text = "&Imprimir";
            this.tsImprimir.Click += new System.EventHandler(this.tsImprimir_Click_1);
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.Color.Black;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenu,
            this.tsNovoDoc,
            this.tsGravarDoc,
            this.tsImprimir,
            this.tsSair,
            this.toolStripMenuItem9});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1544, 55);
            this.menuStrip2.TabIndex = 36;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // tsSair
            // 
            this.tsSair.AutoSize = false;
            this.tsSair.BackColor = System.Drawing.Color.Black;
            this.tsSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsSair.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSair.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsSair.Image = ((System.Drawing.Image)(resources.GetObject("tsSair.Image")));
            this.tsSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsSair.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tsSair.Name = "tsSair";
            this.tsSair.Size = new System.Drawing.Size(70, 37);
            this.tsSair.Text = "Sair";
            this.tsSair.Click += new System.EventHandler(this.tsSair_Click_1);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem9.BackColor = System.Drawing.Color.Black;
            this.toolStripMenuItem9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripMenuItem9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem9.Image")));
            this.toolStripMenuItem9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem9.Margin = new System.Windows.Forms.Padding(100, 0, 0, 0);
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(72, 51);
            this.toolStripMenuItem9.Text = "Info";
            // 
            // BtnNovo
            // 
            this.BtnNovo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnNovo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnNovo.Enabled = false;
            this.BtnNovo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnNovo.FlatAppearance.BorderSize = 2;
            this.BtnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNovo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnNovo.Location = new System.Drawing.Point(12, 332);
            this.BtnNovo.Margin = new System.Windows.Forms.Padding(0);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(107, 38);
            this.BtnNovo.TabIndex = 10;
            this.BtnNovo.Text = "Adicionar";
            this.BtnNovo.UseVisualStyleBackColor = false;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click_1);
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Panel2.Controls.Add(this.cbCategoria);
            this.Panel2.Controls.Add(this.txtMorada);
            this.Panel2.Controls.Add(this.lblFornecedor);
            this.Panel2.Controls.Add(this.TxtTelefone);
            this.Panel2.Controls.Add(this.label10);
            this.Panel2.Controls.Add(this.TxtEmail);
            this.Panel2.Controls.Add(this.TxtCodigoCl);
            this.Panel2.Controls.Add(this.TxtNomeCl);
            this.Panel2.Location = new System.Drawing.Point(12, 207);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1520, 102);
            this.Panel2.TabIndex = 38;
            // 
            // listaProdutosBindingSource
            // 
            this.listaProdutosBindingSource.DataMember = "ListaProdutos";
            this.listaProdutosBindingSource.DataSource = this.dsDocumentos;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnEliminar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnEliminar.Enabled = false;
            this.BtnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnEliminar.FlatAppearance.BorderSize = 2;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ForeColor = System.Drawing.Color.Red;
            this.BtnEliminar.Location = new System.Drawing.Point(129, 332);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(0);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(107, 38);
            this.BtnEliminar.TabIndex = 11;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click_1);
            // 
            // DgridArtigos
            // 
            this.DgridArtigos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            this.DgridArtigos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgridArtigos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgridArtigos.AutoGenerateColumns = false;
            this.DgridArtigos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgridArtigos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridArtigos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgridArtigos.ColumnHeadersHeight = 30;
            this.DgridArtigos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.Observacao,
            this.cabProdutoIDDataGridViewTextBoxColumn,
            this.produtoDataGridViewTextBoxColumn,
            this.Marca,
            this.Categoria,
            this.numLInhaDataGridViewTextBoxColumn,
            this.NomeCategoria,
            this.NomeMarca,
            this.NomeProduto,
            this.iMEIDataGridViewTextBoxColumn,
            this.precoUntDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn});
            this.DgridArtigos.DataSource = this.listaProdutosBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgridArtigos.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgridArtigos.Enabled = false;
            this.DgridArtigos.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DgridArtigos.Location = new System.Drawing.Point(0, 373);
            this.DgridArtigos.Name = "DgridArtigos";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridArtigos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgridArtigos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgridArtigos.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgridArtigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgridArtigos.Size = new System.Drawing.Size(1544, 50);
            this.DgridArtigos.TabIndex = 32;
            this.DgridArtigos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgridArtigos_CellValueChanged);
            this.DgridArtigos.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgridArtigos_RowLeave);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 9;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // Observacao
            // 
            this.Observacao.DataPropertyName = "Observacao";
            this.Observacao.HeaderText = "Observacao";
            this.Observacao.MinimumWidth = 9;
            this.Observacao.Name = "Observacao";
            this.Observacao.Visible = false;
            // 
            // cabProdutoIDDataGridViewTextBoxColumn
            // 
            this.cabProdutoIDDataGridViewTextBoxColumn.DataPropertyName = "CabProdutoID";
            this.cabProdutoIDDataGridViewTextBoxColumn.HeaderText = "CabProdutoID";
            this.cabProdutoIDDataGridViewTextBoxColumn.MinimumWidth = 9;
            this.cabProdutoIDDataGridViewTextBoxColumn.Name = "cabProdutoIDDataGridViewTextBoxColumn";
            this.cabProdutoIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // produtoDataGridViewTextBoxColumn
            // 
            this.produtoDataGridViewTextBoxColumn.DataPropertyName = "Produto";
            this.produtoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.produtoDataGridViewTextBoxColumn.MinimumWidth = 9;
            this.produtoDataGridViewTextBoxColumn.Name = "produtoDataGridViewTextBoxColumn";
            this.produtoDataGridViewTextBoxColumn.Visible = false;
            // 
            // Marca
            // 
            this.Marca.DataPropertyName = "Marca";
            this.Marca.HeaderText = "Marca";
            this.Marca.MinimumWidth = 9;
            this.Marca.Name = "Marca";
            this.Marca.Visible = false;
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 9;
            this.Categoria.Name = "Categoria";
            this.Categoria.Visible = false;
            // 
            // numLInhaDataGridViewTextBoxColumn
            // 
            this.numLInhaDataGridViewTextBoxColumn.DataPropertyName = "NumLInha";
            this.numLInhaDataGridViewTextBoxColumn.HeaderText = "Nº";
            this.numLInhaDataGridViewTextBoxColumn.MinimumWidth = 9;
            this.numLInhaDataGridViewTextBoxColumn.Name = "numLInhaDataGridViewTextBoxColumn";
            // 
            // NomeCategoria
            // 
            this.NomeCategoria.DataPropertyName = "NomeCategoria";
            this.NomeCategoria.HeaderText = "Categoria";
            this.NomeCategoria.MinimumWidth = 9;
            this.NomeCategoria.Name = "NomeCategoria";
            // 
            // NomeMarca
            // 
            this.NomeMarca.DataPropertyName = "NomeMarca";
            this.NomeMarca.HeaderText = "Marca";
            this.NomeMarca.MinimumWidth = 9;
            this.NomeMarca.Name = "NomeMarca";
            // 
            // NomeProduto
            // 
            this.NomeProduto.DataPropertyName = "NomeProduto";
            this.NomeProduto.HeaderText = "Produto";
            this.NomeProduto.MinimumWidth = 9;
            this.NomeProduto.Name = "NomeProduto";
            // 
            // iMEIDataGridViewTextBoxColumn
            // 
            this.iMEIDataGridViewTextBoxColumn.DataPropertyName = "IMEI";
            this.iMEIDataGridViewTextBoxColumn.HeaderText = "IMEI";
            this.iMEIDataGridViewTextBoxColumn.MinimumWidth = 9;
            this.iMEIDataGridViewTextBoxColumn.Name = "iMEIDataGridViewTextBoxColumn";
            // 
            // precoUntDataGridViewTextBoxColumn
            // 
            this.precoUntDataGridViewTextBoxColumn.DataPropertyName = "PrecoUnt";
            this.precoUntDataGridViewTextBoxColumn.HeaderText = "Preco Unt";
            this.precoUntDataGridViewTextBoxColumn.MinimumWidth = 9;
            this.precoUntDataGridViewTextBoxColumn.Name = "precoUntDataGridViewTextBoxColumn";
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.MinimumWidth = 9;
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.MinimumWidth = 9;
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            // 
            // btnAbrirPr
            // 
            this.btnAbrirPr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbrirPr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAbrirPr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAbrirPr.Enabled = false;
            this.btnAbrirPr.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAbrirPr.FlatAppearance.BorderSize = 2;
            this.btnAbrirPr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirPr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirPr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAbrirPr.Location = new System.Drawing.Point(12, 462);
            this.btnAbrirPr.Name = "btnAbrirPr";
            this.btnAbrirPr.Size = new System.Drawing.Size(107, 38);
            this.btnAbrirPr.TabIndex = 12;
            this.btnAbrirPr.Text = "Abrir";
            this.btnAbrirPr.UseVisualStyleBackColor = false;
            this.btnAbrirPr.Click += new System.EventHandler(this.btnAbrirPr_Click_1);
            // 
            // btnNovoPr
            // 
            this.btnNovoPr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNovoPr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNovoPr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNovoPr.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNovoPr.FlatAppearance.BorderSize = 2;
            this.btnNovoPr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoPr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoPr.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnNovoPr.Location = new System.Drawing.Point(128, 462);
            this.btnNovoPr.Name = "btnNovoPr";
            this.btnNovoPr.Size = new System.Drawing.Size(107, 38);
            this.btnNovoPr.TabIndex = 13;
            this.btnNovoPr.Text = "Criar";
            this.btnNovoPr.UseVisualStyleBackColor = false;
            this.btnNovoPr.Click += new System.EventHandler(this.btnNovoPr_Click_1);
            // 
            // btnGravarPr
            // 
            this.btnGravarPr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGravarPr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGravarPr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGravarPr.Enabled = false;
            this.btnGravarPr.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGravarPr.FlatAppearance.BorderSize = 2;
            this.btnGravarPr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGravarPr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravarPr.ForeColor = System.Drawing.Color.Red;
            this.btnGravarPr.Location = new System.Drawing.Point(243, 462);
            this.btnGravarPr.Name = "btnGravarPr";
            this.btnGravarPr.Size = new System.Drawing.Size(107, 38);
            this.btnGravarPr.TabIndex = 44;
            this.btnGravarPr.Text = "Gravar";
            this.btnGravarPr.UseVisualStyleBackColor = false;
            this.btnGravarPr.Click += new System.EventHandler(this.btnGravarPr_Click_1);
            // 
            // FrmDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1544, 770);
            this.Controls.Add(this.btnAbrirPr);
            this.Controls.Add(this.btnNovoPr);
            this.Controls.Add(this.btnGravarPr);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.btnAbrirCliente);
            this.Controls.Add(this.btnNovoCliente);
            this.Controls.Add(this.BtnGravarCliente);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.BtnNovo);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.DgridArtigos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(907, 553);
            this.Name = "FrmDocumentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = resources.GetString("$this.Text");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDocumentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDocumentos)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marcasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriasBindingSource1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaProdutosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgridArtigos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txtMorada;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox NrDoc;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox TxtDescricaoDoc;
        internal System.Windows.Forms.ComboBox TxtCodigoDoc;
        private System.Windows.Forms.BindingSource tipoDocumentosBindingSource;
        private Datasets.DsDocumentos dsDocumentos;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.DateTimePicker DataMod;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txtImei;
        internal System.Windows.Forms.TextBox txtEquipNome;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource marcasBindingSource;
        private Datasets.DsProdutos dsProdutos;
        internal System.Windows.Forms.ComboBox txtMarca;
        internal System.Windows.Forms.ComboBox txtCat;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label lblFornecedor;
        internal System.Windows.Forms.TextBox TxtTelefone;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox TxtEmail;
        internal System.Windows.Forms.TextBox TxtCodigoCl;
        internal System.Windows.Forms.TextBox TxtNomeCl;
        private System.Windows.Forms.Button btnAbrirCliente;
        private System.Windows.Forms.Button btnNovoCliente;
        private System.Windows.Forms.Button BtnGravarCliente;
        internal System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.TextBox txtCodPr;
        internal System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox cBoxEuro;
        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox cBoxPercent;
        internal System.Windows.Forms.TextBox txtDesconto;
        internal System.Windows.Forms.ComboBox txtTipoPr;
        internal System.Windows.Forms.ComboBox txtEstado;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label LblStock;
        internal System.Windows.Forms.Label LblPreco;
        internal System.Windows.Forms.TextBox TxtCusto;
        internal System.Windows.Forms.TextBox TxtPreco;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.DateTimePicker dateTimePicker1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtObservacoes;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtTotal;
        internal System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.ToolStripMenuItem tsGravarDoc;
        private System.Windows.Forms.ToolStripMenuItem tsNovoDoc;
        private System.Windows.Forms.ToolStripMenuItem tsMarcas;
        private System.Windows.Forms.ToolStripMenuItem tsAddMarcas;
        private System.Windows.Forms.ToolStripMenuItem tsMarca;
        private System.Windows.Forms.ToolStripMenuItem tsConsultaCat;
        private System.Windows.Forms.ToolStripMenuItem tsAddCategorias;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tsConsultaForn;
        private System.Windows.Forms.ToolStripMenuItem tsAddForn;
        private System.Windows.Forms.ToolStripMenuItem tsFornecedor;
        private System.Windows.Forms.ToolStripMenuItem tsConsultaCliente;
        private System.Windows.Forms.ToolStripMenuItem tsAddCl;
        private System.Windows.Forms.ToolStripMenuItem tsCliente;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsConsultaProduto;
        private System.Windows.Forms.ToolStripMenuItem tsAddProduto;
        private System.Windows.Forms.ToolStripMenuItem tsProdutos;
        internal System.Windows.Forms.ToolStripMenuItem tsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsImprimir;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsSair;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.Button BtnNovo;
        internal System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.BindingSource listaProdutosBindingSource;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.DataGridView DgridArtigos;
        private System.Windows.Forms.Button btnGravarPr;
        private System.Windows.Forms.Button btnAbrirPr;
        private System.Windows.Forms.Button btnNovoPr;
        private System.Windows.Forms.ToolStripMenuItem tsArmazem;
        private System.Windows.Forms.ToolStripMenuItem tsDocumentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn cabProdutoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn produtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn numLInhaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMEIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoUntDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource categoriasBindingSource1;
        internal System.Windows.Forms.Label lblQtd;
        private System.Windows.Forms.BindingSource categoriasBindingSource;
        private System.Windows.Forms.ComboBox txtQtd;
    }
}

