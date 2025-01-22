namespace TeleBerço
{
    partial class FrmClientes
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
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.BtnSair = new System.Windows.Forms.Button();
            this.BtnGravar = new System.Windows.Forms.Button();
            this.PainelCliente = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtTelefone = new System.Windows.Forms.TextBox();
            this.lblMorada = new System.Windows.Forms.Label();
            this.txtMorada = new System.Windows.Forms.TextBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.categoriasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsProdutos = new TeleBerço.Datasets.DsProdutos();
            this.lblLoja = new System.Windows.Forms.Label();
            this.lblForncedor = new System.Windows.Forms.Label();
            this.TxtCodigoCl = new System.Windows.Forms.TextBox();
            this.LblEmail = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.LblNome = new System.Windows.Forms.Label();
            this.TxtNomeCl = new System.Windows.Forms.TextBox();
            this.LabelCliente = new System.Windows.Forms.Label();
            this.PainelCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoriasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnEliminar.BackColor = System.Drawing.Color.White;
            this.BtnEliminar.Enabled = false;
            this.BtnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ForeColor = System.Drawing.Color.Red;
            this.BtnEliminar.Location = new System.Drawing.Point(248, 14);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(5);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(108, 35);
            this.BtnEliminar.TabIndex = 51;
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
            this.BtnNovo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNovo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnNovo.Location = new System.Drawing.Point(14, 14);
            this.BtnNovo.Margin = new System.Windows.Forms.Padding(5);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(108, 35);
            this.BtnNovo.TabIndex = 50;
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
            this.BtnSair.Font = new System.Drawing.Font("Segoe UI Semibold", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSair.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnSair.Location = new System.Drawing.Point(364, 14);
            this.BtnSair.Margin = new System.Windows.Forms.Padding(5);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(108, 35);
            this.BtnSair.TabIndex = 49;
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
            this.BtnGravar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGravar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnGravar.Location = new System.Drawing.Point(131, 14);
            this.BtnGravar.Margin = new System.Windows.Forms.Padding(5);
            this.BtnGravar.Name = "BtnGravar";
            this.BtnGravar.Size = new System.Drawing.Size(108, 35);
            this.BtnGravar.TabIndex = 48;
            this.BtnGravar.Text = "Gravar";
            this.BtnGravar.UseCompatibleTextRendering = true;
            this.BtnGravar.UseVisualStyleBackColor = false;
            this.BtnGravar.Click += new System.EventHandler(this.BtnGravar_Click);
            // 
            // PainelCliente
            // 
            this.PainelCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PainelCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PainelCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PainelCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PainelCliente.Controls.Add(this.label1);
            this.PainelCliente.Controls.Add(this.label2);
            this.PainelCliente.Controls.Add(this.label3);
            this.PainelCliente.Controls.Add(this.label4);
            this.PainelCliente.Controls.Add(this.TxtTelefone);
            this.PainelCliente.Controls.Add(this.lblMorada);
            this.PainelCliente.Controls.Add(this.txtMorada);
            this.PainelCliente.Controls.Add(this.cbCategoria);
            this.PainelCliente.Controls.Add(this.lblLoja);
            this.PainelCliente.Controls.Add(this.lblForncedor);
            this.PainelCliente.Controls.Add(this.TxtCodigoCl);
            this.PainelCliente.Controls.Add(this.LblEmail);
            this.PainelCliente.Controls.Add(this.TxtEmail);
            this.PainelCliente.Controls.Add(this.LblNome);
            this.PainelCliente.Controls.Add(this.TxtNomeCl);
            this.PainelCliente.Controls.Add(this.LabelCliente);
            this.PainelCliente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PainelCliente.Location = new System.Drawing.Point(14, 59);
            this.PainelCliente.Margin = new System.Windows.Forms.Padding(5);
            this.PainelCliente.Name = "PainelCliente";
            this.PainelCliente.Size = new System.Drawing.Size(1238, 252);
            this.PainelCliente.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 193);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 27;
            this.label1.Text = "Categoria :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(200, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Contato :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(198, 135);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 27);
            this.label3.TabIndex = 25;
            this.label3.Text = "Email :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(200, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 26);
            this.label4.TabIndex = 24;
            this.label4.Text = "Nrº :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtTelefone
            // 
            this.TxtTelefone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTelefone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTelefone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTelefone.Location = new System.Drawing.Point(291, 135);
            this.TxtTelefone.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.TxtTelefone.Name = "TxtTelefone";
            this.TxtTelefone.Size = new System.Drawing.Size(206, 29);
            this.TxtTelefone.TabIndex = 3;
            // 
            // lblMorada
            // 
            this.lblMorada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMorada.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMorada.Location = new System.Drawing.Point(543, 188);
            this.lblMorada.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMorada.Name = "lblMorada";
            this.lblMorada.Size = new System.Drawing.Size(71, 27);
            this.lblMorada.TabIndex = 22;
            this.lblMorada.Text = "Morada :";
            this.lblMorada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMorada
            // 
            this.txtMorada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMorada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMorada.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMorada.Location = new System.Drawing.Point(627, 186);
            this.txtMorada.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.txtMorada.Name = "txtMorada";
            this.txtMorada.Size = new System.Drawing.Size(469, 29);
            this.txtMorada.TabIndex = 6;
            // 
            // cbCategoria
            // 
            this.cbCategoria.DataSource = this.categoriasBindingSource;
            this.cbCategoria.DisplayMember = "Nome";
            this.cbCategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(291, 188);
            this.cbCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(206, 29);
            this.cbCategoria.TabIndex = 5;
            this.cbCategoria.ValueMember = "CodCat";
            // 
            // categoriasBindingSource
            // 
            this.categoriasBindingSource.DataMember = "Categorias";
            this.categoriasBindingSource.DataSource = this.dsProdutos;
            // 
            // dsProdutos
            // 
            this.dsProdutos.DataSetName = "DsProdutos";
            this.dsProdutos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblLoja
            // 
            this.lblLoja.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoja.Location = new System.Drawing.Point(543, 139);
            this.lblLoja.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLoja.Name = "lblLoja";
            this.lblLoja.Size = new System.Drawing.Size(41, 25);
            this.lblLoja.TabIndex = 19;
            this.lblLoja.Text = "Site :";
            this.lblLoja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblForncedor
            // 
            this.lblForncedor.AutoSize = true;
            this.lblForncedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForncedor.Location = new System.Drawing.Point(26, 38);
            this.lblForncedor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblForncedor.Name = "lblForncedor";
            this.lblForncedor.Size = new System.Drawing.Size(101, 20);
            this.lblForncedor.TabIndex = 18;
            this.lblForncedor.Text = "Fornecedor";
            // 
            // TxtCodigoCl
            // 
            this.TxtCodigoCl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCodigoCl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCodigoCl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigoCl.Location = new System.Drawing.Point(291, 85);
            this.TxtCodigoCl.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.TxtCodigoCl.Name = "TxtCodigoCl";
            this.TxtCodigoCl.Size = new System.Drawing.Size(206, 29);
            this.TxtCodigoCl.TabIndex = 1;
            this.TxtCodigoCl.Leave += new System.EventHandler(this.TxtCodigoCl_Leave);
            // 
            // LblEmail
            // 
            this.LblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEmail.Location = new System.Drawing.Point(541, 135);
            this.LblEmail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(65, 27);
            this.LblEmail.TabIndex = 15;
            this.LblEmail.Text = "Email :";
            this.LblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtEmail
            // 
            this.TxtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.Location = new System.Drawing.Point(627, 133);
            this.TxtEmail.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(469, 29);
            this.TxtEmail.TabIndex = 4;
            // 
            // LblNome
            // 
            this.LblNome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblNome.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNome.Location = new System.Drawing.Point(543, 85);
            this.LblNome.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LblNome.Name = "LblNome";
            this.LblNome.Size = new System.Drawing.Size(52, 26);
            this.LblNome.TabIndex = 11;
            this.LblNome.Text = "Nome :";
            this.LblNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtNomeCl
            // 
            this.TxtNomeCl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNomeCl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNomeCl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNomeCl.Location = new System.Drawing.Point(627, 82);
            this.TxtNomeCl.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.TxtNomeCl.Name = "TxtNomeCl";
            this.TxtNomeCl.Size = new System.Drawing.Size(469, 29);
            this.TxtNomeCl.TabIndex = 2;
            // 
            // LabelCliente
            // 
            this.LabelCliente.AutoSize = true;
            this.LabelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCliente.Location = new System.Drawing.Point(26, 38);
            this.LabelCliente.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LabelCliente.Name = "LabelCliente";
            this.LabelCliente.Size = new System.Drawing.Size(65, 20);
            this.LabelCliente.TabIndex = 1;
            this.LabelCliente.Text = "Cliente";
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 325);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnNovo);
            this.Controls.Add(this.BtnSair);
            this.Controls.Add(this.BtnGravar);
            this.Controls.Add(this.PainelCliente);
            this.Name = "FrmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmClientes";
            this.Load += new System.EventHandler(this.FrmClientes_Load_1);
            this.PainelCliente.ResumeLayout(false);
            this.PainelCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoriasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProdutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button BtnEliminar;
        internal System.Windows.Forms.Button BtnNovo;
        internal System.Windows.Forms.Button BtnSair;
        internal System.Windows.Forms.Button BtnGravar;
        internal System.Windows.Forms.Panel PainelCliente;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox TxtTelefone;
        internal System.Windows.Forms.Label lblMorada;
        internal System.Windows.Forms.TextBox txtMorada;
        private System.Windows.Forms.ComboBox cbCategoria;
        internal System.Windows.Forms.Label lblLoja;
        internal System.Windows.Forms.Label lblForncedor;
        internal System.Windows.Forms.TextBox TxtCodigoCl;
        internal System.Windows.Forms.Label LblEmail;
        internal System.Windows.Forms.TextBox TxtEmail;
        internal System.Windows.Forms.Label LblNome;
        internal System.Windows.Forms.TextBox TxtNomeCl;
        internal System.Windows.Forms.Label LabelCliente;
        private Datasets.DsProdutos dsProdutos;
        private System.Windows.Forms.BindingSource categoriasBindingSource;
    }
}