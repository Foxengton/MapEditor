namespace MapEditor
{
    partial class GameMap
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.ButtonMapScreenShot = new System.Windows.Forms.Button();
			this.CoordinatesText = new System.Windows.Forms.TextBox();
			this.ButtonMapLoad = new System.Windows.Forms.Button();
			this.ButtonMapSave = new System.Windows.Forms.Button();
			this.MapBox = new System.Windows.Forms.PictureBox();
			this.GexesList = new System.Windows.Forms.ImageList(this.components);
			this.BackgroundSelect = new System.Windows.Forms.ComboBox();
			this.ButtonsBox = new System.Windows.Forms.GroupBox();
			this.BackgroundBox = new System.Windows.Forms.GroupBox();
			this.FogOfWarCheck = new System.Windows.Forms.CheckBox();
			this.RiverCheck = new System.Windows.Forms.CheckBox();
			this.RoadCheck = new System.Windows.Forms.CheckBox();
			this.ModeGodCheck = new System.Windows.Forms.CheckBox();
			this.NationBox = new System.Windows.Forms.GroupBox();
			this.NationSelect = new System.Windows.Forms.ComboBox();
			this.ButtonNationSave = new System.Windows.Forms.Button();
			this.ButtonNationAdd = new System.Windows.Forms.Button();
			this.ButtonNationLoad = new System.Windows.Forms.Button();
			this.ButtonNationDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.MapBox)).BeginInit();
			this.ButtonsBox.SuspendLayout();
			this.BackgroundBox.SuspendLayout();
			this.NationBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonMapScreenShot
			// 
			this.ButtonMapScreenShot.Enabled = false;
			this.ButtonMapScreenShot.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ButtonMapScreenShot.Location = new System.Drawing.Point(3, 26);
			this.ButtonMapScreenShot.Name = "ButtonMapScreenShot";
			this.ButtonMapScreenShot.Size = new System.Drawing.Size(267, 30);
			this.ButtonMapScreenShot.TabIndex = 0;
			this.ButtonMapScreenShot.Text = "Скриншот";
			this.ButtonMapScreenShot.UseVisualStyleBackColor = true;
			this.ButtonMapScreenShot.Click += new System.EventHandler(this.ButtonSaveScreen_Click);
			// 
			// CoordinatesText
			// 
			this.CoordinatesText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CoordinatesText.Enabled = false;
			this.CoordinatesText.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CoordinatesText.Location = new System.Drawing.Point(502, 337);
			this.CoordinatesText.Name = "CoordinatesText";
			this.CoordinatesText.Size = new System.Drawing.Size(273, 30);
			this.CoordinatesText.TabIndex = 3;
			this.CoordinatesText.TabStop = false;
			this.CoordinatesText.Text = "Координаты: 0, 0";
			// 
			// ButtonMapLoad
			// 
			this.ButtonMapLoad.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ButtonMapLoad.Location = new System.Drawing.Point(3, 86);
			this.ButtonMapLoad.Name = "ButtonMapLoad";
			this.ButtonMapLoad.Size = new System.Drawing.Size(267, 30);
			this.ButtonMapLoad.TabIndex = 4;
			this.ButtonMapLoad.Text = "Загрузить";
			this.ButtonMapLoad.UseVisualStyleBackColor = true;
			this.ButtonMapLoad.Click += new System.EventHandler(this.ButtonLoadMap_Click);
			// 
			// ButtonMapSave
			// 
			this.ButtonMapSave.Enabled = false;
			this.ButtonMapSave.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ButtonMapSave.Location = new System.Drawing.Point(3, 56);
			this.ButtonMapSave.Name = "ButtonMapSave";
			this.ButtonMapSave.Size = new System.Drawing.Size(267, 30);
			this.ButtonMapSave.TabIndex = 5;
			this.ButtonMapSave.Text = "Сохранить";
			this.ButtonMapSave.UseVisualStyleBackColor = true;
			this.ButtonMapSave.Click += new System.EventHandler(this.ButtonSaveMap_Click);
			// 
			// MapBox
			// 
			this.MapBox.BackColor = System.Drawing.Color.Silver;
			this.MapBox.Location = new System.Drawing.Point(9, 9);
			this.MapBox.Margin = new System.Windows.Forms.Padding(0);
			this.MapBox.Name = "MapBox";
			this.MapBox.Size = new System.Drawing.Size(490, 483);
			this.MapBox.TabIndex = 0;
			this.MapBox.TabStop = false;
			this.MapBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapBox_MouseDown);
			this.MapBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapBox_MouseMove);
			// 
			// GexesList
			// 
			this.GexesList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.GexesList.ImageSize = new System.Drawing.Size(31, 31);
			this.GexesList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// BackgroundSelect
			// 
			this.BackgroundSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BackgroundSelect.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.BackgroundSelect.Location = new System.Drawing.Point(3, 26);
			this.BackgroundSelect.Name = "BackgroundSelect";
			this.BackgroundSelect.Size = new System.Drawing.Size(264, 31);
			this.BackgroundSelect.TabIndex = 7;
			this.BackgroundSelect.TabStop = false;
			this.BackgroundSelect.SelectedIndexChanged += new System.EventHandler(this.BacksBox_SelectedIndexChanged);
			// 
			// ButtonsBox
			// 
			this.ButtonsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonsBox.Controls.Add(this.ButtonMapLoad);
			this.ButtonsBox.Controls.Add(this.ButtonMapSave);
			this.ButtonsBox.Controls.Add(this.ButtonMapScreenShot);
			this.ButtonsBox.Location = new System.Drawing.Point(502, 373);
			this.ButtonsBox.Name = "ButtonsBox";
			this.ButtonsBox.Padding = new System.Windows.Forms.Padding(0);
			this.ButtonsBox.Size = new System.Drawing.Size(273, 119);
			this.ButtonsBox.TabIndex = 10;
			this.ButtonsBox.TabStop = false;
			this.ButtonsBox.Text = "Кнопки";
			// 
			// BackgroundBox
			// 
			this.BackgroundBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BackgroundBox.Controls.Add(this.FogOfWarCheck);
			this.BackgroundBox.Controls.Add(this.RiverCheck);
			this.BackgroundBox.Controls.Add(this.RoadCheck);
			this.BackgroundBox.Controls.Add(this.BackgroundSelect);
			this.BackgroundBox.Location = new System.Drawing.Point(502, 42);
			this.BackgroundBox.Name = "BackgroundBox";
			this.BackgroundBox.Padding = new System.Windows.Forms.Padding(0);
			this.BackgroundBox.Size = new System.Drawing.Size(273, 132);
			this.BackgroundBox.TabIndex = 11;
			this.BackgroundBox.TabStop = false;
			this.BackgroundBox.Text = "Фон";
			// 
			// FogOfWarCheck
			// 
			this.FogOfWarCheck.Location = new System.Drawing.Point(3, 99);
			this.FogOfWarCheck.Name = "FogOfWarCheck";
			this.FogOfWarCheck.Size = new System.Drawing.Size(129, 30);
			this.FogOfWarCheck.TabIndex = 10;
			this.FogOfWarCheck.Text = "Туман войны";
			this.FogOfWarCheck.UseVisualStyleBackColor = true;
			this.FogOfWarCheck.CheckedChanged += new System.EventHandler(this.BacksBox_SelectedIndexChanged);
			// 
			// RiverCheck
			// 
			this.RiverCheck.Location = new System.Drawing.Point(138, 63);
			this.RiverCheck.Name = "RiverCheck";
			this.RiverCheck.Size = new System.Drawing.Size(129, 30);
			this.RiverCheck.TabIndex = 9;
			this.RiverCheck.Text = "Река";
			this.RiverCheck.UseVisualStyleBackColor = true;
			this.RiverCheck.CheckedChanged += new System.EventHandler(this.BacksBox_SelectedIndexChanged);
			// 
			// RoadCheck
			// 
			this.RoadCheck.Location = new System.Drawing.Point(3, 63);
			this.RoadCheck.Name = "RoadCheck";
			this.RoadCheck.Size = new System.Drawing.Size(129, 30);
			this.RoadCheck.TabIndex = 8;
			this.RoadCheck.Text = "Дорога";
			this.RoadCheck.UseVisualStyleBackColor = true;
			this.RoadCheck.CheckedChanged += new System.EventHandler(this.BacksBox_SelectedIndexChanged);
			// 
			// ModeGodCheck
			// 
			this.ModeGodCheck.Location = new System.Drawing.Point(640, 9);
			this.ModeGodCheck.Margin = new System.Windows.Forms.Padding(0);
			this.ModeGodCheck.Name = "ModeGodCheck";
			this.ModeGodCheck.Size = new System.Drawing.Size(129, 30);
			this.ModeGodCheck.TabIndex = 11;
			this.ModeGodCheck.Text = "Режим Бога";
			this.ModeGodCheck.UseVisualStyleBackColor = true;
			this.ModeGodCheck.CheckedChanged += new System.EventHandler(this.ModeGodCheck_CheckedChanged);
			// 
			// NationBox
			// 
			this.NationBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NationBox.Controls.Add(this.ButtonNationDelete);
			this.NationBox.Controls.Add(this.ButtonNationLoad);
			this.NationBox.Controls.Add(this.ButtonNationAdd);
			this.NationBox.Controls.Add(this.ButtonNationSave);
			this.NationBox.Controls.Add(this.NationSelect);
			this.NationBox.Location = new System.Drawing.Point(502, 180);
			this.NationBox.Margin = new System.Windows.Forms.Padding(0);
			this.NationBox.Name = "NationBox";
			this.NationBox.Padding = new System.Windows.Forms.Padding(0);
			this.NationBox.Size = new System.Drawing.Size(273, 132);
			this.NationBox.TabIndex = 12;
			this.NationBox.TabStop = false;
			this.NationBox.Text = "Нация";
			// 
			// NationSelect
			// 
			this.NationSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.NationSelect.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.NationSelect.Location = new System.Drawing.Point(3, 26);
			this.NationSelect.Name = "NationSelect";
			this.NationSelect.Size = new System.Drawing.Size(264, 31);
			this.NationSelect.TabIndex = 7;
			this.NationSelect.TabStop = false;
			// 
			// ButtonNationSave
			// 
			this.ButtonNationSave.Enabled = false;
			this.ButtonNationSave.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ButtonNationSave.Location = new System.Drawing.Point(138, 99);
			this.ButtonNationSave.Name = "ButtonNationSave";
			this.ButtonNationSave.Size = new System.Drawing.Size(132, 30);
			this.ButtonNationSave.TabIndex = 6;
			this.ButtonNationSave.Text = "Сохранить";
			this.ButtonNationSave.UseVisualStyleBackColor = true;
			// 
			// ButtonNationAdd
			// 
			this.ButtonNationAdd.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ButtonNationAdd.Location = new System.Drawing.Point(3, 63);
			this.ButtonNationAdd.Name = "ButtonNationAdd";
			this.ButtonNationAdd.Size = new System.Drawing.Size(129, 30);
			this.ButtonNationAdd.TabIndex = 8;
			this.ButtonNationAdd.Text = "Добавить";
			this.ButtonNationAdd.UseVisualStyleBackColor = true;
			// 
			// ButtonNationLoad
			// 
			this.ButtonNationLoad.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ButtonNationLoad.Location = new System.Drawing.Point(3, 99);
			this.ButtonNationLoad.Name = "ButtonNationLoad";
			this.ButtonNationLoad.Size = new System.Drawing.Size(129, 30);
			this.ButtonNationLoad.TabIndex = 9;
			this.ButtonNationLoad.Text = "Загрузить";
			this.ButtonNationLoad.UseVisualStyleBackColor = true;
			// 
			// ButtonNationDelete
			// 
			this.ButtonNationDelete.Enabled = false;
			this.ButtonNationDelete.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ButtonNationDelete.Location = new System.Drawing.Point(138, 63);
			this.ButtonNationDelete.Name = "ButtonNationDelete";
			this.ButtonNationDelete.Size = new System.Drawing.Size(132, 30);
			this.ButtonNationDelete.TabIndex = 10;
			this.ButtonNationDelete.Text = "Удалить";
			this.ButtonNationDelete.UseVisualStyleBackColor = true;
			// 
			// GameMap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 501);
			this.Controls.Add(this.ModeGodCheck);
			this.Controls.Add(this.ButtonsBox);
			this.Controls.Add(this.CoordinatesText);
			this.Controls.Add(this.MapBox);
			this.Controls.Add(this.NationBox);
			this.Controls.Add(this.BackgroundBox);
			this.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "GameMap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Map Editor";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapEditor_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapEditor_KeyDown);
			this.Resize += new System.EventHandler(this.MapEditor_Resize);
			((System.ComponentModel.ISupportInitialize)(this.MapBox)).EndInit();
			this.ButtonsBox.ResumeLayout(false);
			this.BackgroundBox.ResumeLayout(false);
			this.NationBox.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonMapScreenShot;
        private System.Windows.Forms.TextBox CoordinatesText;
        private System.Windows.Forms.Button ButtonMapLoad;
        private System.Windows.Forms.Button ButtonMapSave;
        private System.Windows.Forms.PictureBox MapBox;
		private System.Windows.Forms.ImageList GexesList;
		private System.Windows.Forms.ComboBox BackgroundSelect;
		private System.Windows.Forms.GroupBox ButtonsBox;
		private System.Windows.Forms.GroupBox BackgroundBox;
		private System.Windows.Forms.CheckBox RiverCheck;
		private System.Windows.Forms.CheckBox RoadCheck;
		private System.Windows.Forms.CheckBox FogOfWarCheck;
		private System.Windows.Forms.CheckBox ModeGodCheck;
		private System.Windows.Forms.GroupBox NationBox;
		private System.Windows.Forms.ComboBox NationSelect;
		private System.Windows.Forms.Button ButtonNationSave;
		private System.Windows.Forms.Button ButtonNationDelete;
		private System.Windows.Forms.Button ButtonNationLoad;
		private System.Windows.Forms.Button ButtonNationAdd;
	}
}

