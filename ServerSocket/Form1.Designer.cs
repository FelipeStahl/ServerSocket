namespace Exemplo
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbInfoConexao = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressOverall = new System.Windows.Forms.ToolStripProgressBar();
            this.lstTransfers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btEnviarArquivo = new System.Windows.Forms.Button();
            this.btCliente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txIp = new System.Windows.Forms.TextBox();
            this.txPorta = new System.Windows.Forms.TextBox();
            this.btServidor = new System.Windows.Forms.Button();
            this.menuTransfers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnSendFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStopTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPauseTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClearComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuTransfers.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(159, 329);
            this.listBox1.TabIndex = 33;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbInfoConexao,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.progressOverall});
            this.statusStrip1.Location = new System.Drawing.Point(0, 400);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(589, 22);
            this.statusStrip1.TabIndex = 32;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbInfoConexao
            // 
            this.lbInfoConexao.Name = "lbInfoConexao";
            this.lbInfoConexao.Size = new System.Drawing.Size(370, 17);
            this.lbInfoConexao.Spring = true;
            this.lbInfoConexao.Text = "Connection: -";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(92, 17);
            this.toolStripStatusLabel3.Text = "Overall Progress";
            // 
            // progressOverall
            // 
            this.progressOverall.Name = "progressOverall";
            this.progressOverall.Size = new System.Drawing.Size(100, 16);
            this.progressOverall.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // lstTransfers
            // 
            this.lstTransfers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTransfers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lstTransfers.FullRowSelect = true;
            this.lstTransfers.HideSelection = false;
            this.lstTransfers.Location = new System.Drawing.Point(177, 47);
            this.lstTransfers.Name = "lstTransfers";
            this.lstTransfers.Size = new System.Drawing.Size(403, 310);
            this.lstTransfers.TabIndex = 31;
            this.lstTransfers.UseCompatibleStateImageBehavior = false;
            this.lstTransfers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 79;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Filename";
            this.columnHeader5.Width = 171;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Type";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 72;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Progress";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader7.Width = 68;
            // 
            // btEnviarArquivo
            // 
            this.btEnviarArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btEnviarArquivo.Location = new System.Drawing.Point(12, 362);
            this.btEnviarArquivo.Name = "btEnviarArquivo";
            this.btEnviarArquivo.Size = new System.Drawing.Size(568, 23);
            this.btEnviarArquivo.TabIndex = 30;
            this.btEnviarArquivo.Text = "Enviar Arquivo";
            this.btEnviarArquivo.UseVisualStyleBackColor = true;
            this.btEnviarArquivo.Click += new System.EventHandler(this.btEnviarArquivo_Click);
            // 
            // btCliente
            // 
            this.btCliente.Location = new System.Drawing.Point(470, 20);
            this.btCliente.Name = "btCliente";
            this.btCliente.Size = new System.Drawing.Size(108, 23);
            this.btCliente.TabIndex = 28;
            this.btCliente.Text = "Iniciar Cliente";
            this.btCliente.UseVisualStyleBackColor = true;
            this.btCliente.Click += new System.EventHandler(this.btCliente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "IP Servidor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Porta";
            // 
            // txIp
            // 
            this.txIp.Location = new System.Drawing.Point(244, 22);
            this.txIp.Name = "txIp";
            this.txIp.Size = new System.Drawing.Size(102, 20);
            this.txIp.TabIndex = 25;
            // 
            // txPorta
            // 
            this.txPorta.Location = new System.Drawing.Point(177, 22);
            this.txPorta.Name = "txPorta";
            this.txPorta.Size = new System.Drawing.Size(61, 20);
            this.txPorta.TabIndex = 24;
            this.txPorta.Text = "100";
            // 
            // btServidor
            // 
            this.btServidor.Location = new System.Drawing.Point(356, 20);
            this.btServidor.Name = "btServidor";
            this.btServidor.Size = new System.Drawing.Size(108, 23);
            this.btServidor.TabIndex = 23;
            this.btServidor.Text = "Iniciar Servidor";
            this.btServidor.UseVisualStyleBackColor = true;
            this.btServidor.Click += new System.EventHandler(this.btServidor_Click);
            // 
            // menuTransfers
            // 
            this.menuTransfers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSendFile,
            this.btnStopTransfer,
            this.btnPauseTransfer,
            this.toolStripMenuItem1,
            this.btnClearComplete});
            this.menuTransfers.Name = "contextMenuStrip1";
            this.menuTransfers.Size = new System.Drawing.Size(181, 120);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(156, 22);
            this.btnSendFile.Text = "Send";
            // 
            // btnStopTransfer
            // 
            this.btnStopTransfer.Name = "btnStopTransfer";
            this.btnStopTransfer.Size = new System.Drawing.Size(180, 22);
            this.btnStopTransfer.Text = "Stop";
            this.btnStopTransfer.Click += new System.EventHandler(this.btnStopTransfer_Click);
            // 
            // btnPauseTransfer
            // 
            this.btnPauseTransfer.Name = "btnPauseTransfer";
            this.btnPauseTransfer.Size = new System.Drawing.Size(156, 22);
            this.btnPauseTransfer.Text = "Pause";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            // 
            // btnClearComplete
            // 
            this.btnClearComplete.Name = "btnClearComplete";
            this.btnClearComplete.Size = new System.Drawing.Size(156, 22);
            this.btnClearComplete.Text = "Clear Complete";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 422);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lstTransfers);
            this.Controls.Add(this.btEnviarArquivo);
            this.Controls.Add(this.btCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txIp);
            this.Controls.Add(this.txPorta);
            this.Controls.Add(this.btServidor);
            this.Name = "Form1";
            this.Text = "Server";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuTransfers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbInfoConexao;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripProgressBar progressOverall;
        private System.Windows.Forms.ListView lstTransfers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btEnviarArquivo;
        private System.Windows.Forms.Button btCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txIp;
        private System.Windows.Forms.TextBox txPorta;
        private System.Windows.Forms.Button btServidor;
        private System.Windows.Forms.ContextMenuStrip menuTransfers;
        private System.Windows.Forms.ToolStripMenuItem btnSendFile;
        private System.Windows.Forms.ToolStripMenuItem btnStopTransfer;
        private System.Windows.Forms.ToolStripMenuItem btnPauseTransfer;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnClearComplete;
    }
}

