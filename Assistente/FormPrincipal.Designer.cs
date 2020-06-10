namespace Assistente
{
    partial class FormPrincipal
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
            System.Windows.Forms.DataVisualization.Charting.HorizontalLineAnnotation horizontalLineAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.HorizontalLineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxProjeto = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.LeadTimeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.leadTimeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LeadTimeChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leadTimeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Projeto";
            // 
            // cbxProjeto
            // 
            this.cbxProjeto.FormattingEnabled = true;
            this.cbxProjeto.Location = new System.Drawing.Point(72, 13);
            this.cbxProjeto.Name = "cbxProjeto";
            this.cbxProjeto.Size = new System.Drawing.Size(442, 21);
            this.cbxProjeto.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(520, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // LeadTimeChart
            // 
            this.LeadTimeChart.AllowDrop = true;
            horizontalLineAnnotation1.Name = "HorizontalLineAnnotation1";
            this.LeadTimeChart.Annotations.Add(horizontalLineAnnotation1);
            chartArea1.Name = "DistribLeadTime";
            this.LeadTimeChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.LeadTimeChart.Legends.Add(legend1);
            this.LeadTimeChart.Location = new System.Drawing.Point(16, 61);
            this.LeadTimeChart.Name = "LeadTimeChart";
            this.LeadTimeChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series1.ChartArea = "DistribLeadTime";
            series1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelAngle = 90;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.LeadTimeChart.Series.Add(series1);
            this.LeadTimeChart.Size = new System.Drawing.Size(895, 189);
            this.LeadTimeChart.TabIndex = 3;
            this.LeadTimeChart.Text = "Distribuição de Leadtime";
            title1.Name = "Title1";
            this.LeadTimeChart.Titles.Add(title1);
            this.LeadTimeChart.UseWaitCursor = true;
            // 
            // leadTimeBindingSource
            // 
            this.leadTimeBindingSource.DataSource = typeof(Assistente.Extracao.LeadTime);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 450);
            this.Controls.Add(this.LeadTimeChart);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbxProjeto);
            this.Controls.Add(this.label1);
            this.Name = "FormPrincipal";
            this.Text = "Assistente Integração Jira";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LeadTimeChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leadTimeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxProjeto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataVisualization.Charting.Chart LeadTimeChart;
        private System.Windows.Forms.BindingSource leadTimeBindingSource;
    }
}

