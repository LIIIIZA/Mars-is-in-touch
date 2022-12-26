using System.Windows.Forms.DataVisualization.Charting;

namespace Mars
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.textBoxDT = new System.Windows.Forms.TextBox();
            this.chartTrajectory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelDT = new System.Windows.Forms.Label();
            this.labelMinT = new System.Windows.Forms.Label();
            this.textBoxMinT = new System.Windows.Forms.TextBox();
            this.labelMaxT = new System.Windows.Forms.Label();
            this.textBoxMaxT = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelStatusMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrajectory)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(1285, 230);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(100, 40);
            this.buttonCalculate.TabIndex = 0;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // textBoxDT
            // 
            this.textBoxDT.Location = new System.Drawing.Point(1285, 50);
            this.textBoxDT.Name = "textBoxDT";
            this.textBoxDT.Size = new System.Drawing.Size(100, 22);
            this.textBoxDT.TabIndex = 1;
            // 
            // chartTrajectory
            // 
            chartArea6.Name = "ChartArea1";
            this.chartTrajectory.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartTrajectory.Legends.Add(legend6);
            this.chartTrajectory.Location = new System.Drawing.Point(20, 20);
            this.chartTrajectory.Name = "chartTrajectory";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Legend = "Legend1";
            series6.Name = "Trajectory";
            this.chartTrajectory.Series.Add(series6);
            this.chartTrajectory.Size = new System.Drawing.Size(1200, 800);
            this.chartTrajectory.TabIndex = 2;
            // 
            // labelDT
            // 
            this.labelDT.Location = new System.Drawing.Point(1285, 20);
            this.labelDT.Name = "labelDT";
            this.labelDT.Size = new System.Drawing.Size(100, 20);
            this.labelDT.TabIndex = 3;
            this.labelDT.Text = "Enter Δt :";
            this.labelDT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMinT
            // 
            this.labelMinT.Location = new System.Drawing.Point(1285, 90);
            this.labelMinT.Name = "labelMinT";
            this.labelMinT.Size = new System.Drawing.Size(100, 20);
            this.labelMinT.TabIndex = 5;
            this.labelMinT.Text = "Min t :";
            this.labelMinT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMinT
            // 
            this.textBoxMinT.Location = new System.Drawing.Point(1285, 120);
            this.textBoxMinT.Name = "textBoxMinT";
            this.textBoxMinT.Size = new System.Drawing.Size(100, 22);
            this.textBoxMinT.TabIndex = 4;
            // 
            // labelMaxT
            // 
            this.labelMaxT.Location = new System.Drawing.Point(1285, 160);
            this.labelMaxT.Name = "labelMaxT";
            this.labelMaxT.Size = new System.Drawing.Size(100, 20);
            this.labelMaxT.TabIndex = 7;
            this.labelMaxT.Text = "Max t :";
            this.labelMaxT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMaxT
            // 
            this.textBoxMaxT.Location = new System.Drawing.Point(1285, 190);
            this.textBoxMaxT.Name = "textBoxMaxT";
            this.textBoxMaxT.Size = new System.Drawing.Size(100, 22);
            this.textBoxMaxT.TabIndex = 6;
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(1285, 300);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(100, 20);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "Status:";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStatusMessage
            // 
            this.labelStatusMessage.Location = new System.Drawing.Point(1240, 330);
            this.labelStatusMessage.Name = "labelStatusMessage";
            this.labelStatusMessage.Size = new System.Drawing.Size(250, 200);
            this.labelStatusMessage.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1512, 843);
            this.Controls.Add(this.labelStatusMessage);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelMaxT);
            this.Controls.Add(this.textBoxMaxT);
            this.Controls.Add(this.labelMinT);
            this.Controls.Add(this.textBoxMinT);
            this.Controls.Add(this.labelDT);
            this.Controls.Add(this.chartTrajectory);
            this.Controls.Add(this.textBoxDT);
            this.Controls.Add(this.buttonCalculate);
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.chartTrajectory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.TextBox textBoxDT;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTrajectory;
        private System.Windows.Forms.Label labelDT;
        private System.Windows.Forms.Label labelMinT;
        private System.Windows.Forms.TextBox textBoxMinT;
        private System.Windows.Forms.Label labelMaxT;
        private System.Windows.Forms.TextBox textBoxMaxT;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelStatusMessage;
    }
}

