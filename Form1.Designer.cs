
namespace Plateformeur
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.enemyPicture1 = new System.Windows.Forms.PictureBox();
            this.playerPicture = new System.Windows.Forms.PictureBox();
            this.coinPicture1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPicture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coinPicture1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.OnUpdateTick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.enemyPicture1);
            this.panel1.Controls.Add(this.playerPicture);
            this.panel1.Controls.Add(this.coinPicture1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 489);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // enemyPicture1
            // 
            this.enemyPicture1.Image = ((System.Drawing.Image)(resources.GetObject("enemyPicture1.Image")));
            this.enemyPicture1.Location = new System.Drawing.Point(511, 176);
            this.enemyPicture1.Name = "enemyPicture1";
            this.enemyPicture1.Size = new System.Drawing.Size(30, 30);
            this.enemyPicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.enemyPicture1.TabIndex = 2;
            this.enemyPicture1.TabStop = false;
            // 
            // playerPicture
            // 
            this.playerPicture.Image = ((System.Drawing.Image)(resources.GetObject("playerPicture.Image")));
            this.playerPicture.Location = new System.Drawing.Point(316, 176);
            this.playerPicture.Name = "playerPicture";
            this.playerPicture.Size = new System.Drawing.Size(30, 30);
            this.playerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playerPicture.TabIndex = 1;
            this.playerPicture.TabStop = false;
            // 
            // coinPicture1
            // 
            this.coinPicture1.Image = ((System.Drawing.Image)(resources.GetObject("coinPicture1.Image")));
            this.coinPicture1.Location = new System.Drawing.Point(452, 161);
            this.coinPicture1.Name = "coinPicture1";
            this.coinPicture1.Size = new System.Drawing.Size(15, 15);
            this.coinPicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.coinPicture1.TabIndex = 0;
            this.coinPicture1.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(571, 489);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.enemyPicture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coinPicture1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox coinPicture1;
        private System.Windows.Forms.PictureBox playerPicture;
        private System.Windows.Forms.PictureBox enemyPicture1;
    }
}

