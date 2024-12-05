namespace WormGearKursovaya;

public partial class MainForm : System.Windows.Forms.Form
    {
        private TextBox txtQ, txtSigmaHP, txtEfficiency, txtPowerN1, txtSigmaFP;
        private TextBox txtAW, txtD2, txtX, txtM, eqCycleTime;
        private ComboBox cmbZ2, cmbZ1, cmbMat;
        private Button btnCalculate;
        private ToolTip toolTip;
        
        private List<Double> z2Values = new List<Double>(){ 20, 24, 26, 28, 30, 32, 35, 37, 40, 45, 50, 60, 80, 100, 150 };
        private List<double> z1Values = new List<double>() { 1, 2, 3, 4 };
        private List<string> materials = new List<string>() { "латунь", "бронза", "чугун"};

        
        private void InitializeComponent()
        {
            this.Text = "Калькулятор червячной передачи";
            this.Size = new Size(650, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Создаем ToolTip
            toolTip = new ToolTip();

            // Вводные данные
            var groupBoxInput = CreateGroupBox("Вводные данные", 20, 1, 600, 400);

            var labelZ2 = CreateLabel("Количество зубьев червячного колеса z2:", 20, 20);
            cmbZ2 = CreateComboBox(400, 20, z2Values);
            toolTip.SetToolTip(cmbZ2, "Введите количество зубьев червячного колеса");

            var labelZ1 = CreateLabel("Число витков червяка z1:", 20, 60);
            cmbZ1 = CreateComboBox(400, 60, z1Values);
            toolTip.SetToolTip(cmbZ1, "Введите число витков червяка");

            var labelQ = CreateLabel("Передаточное число q:", 20, 100);
            txtQ = CreateTextBox(400, 100);
            toolTip.SetToolTip(txtQ, "Введите передаточное число");

            var labelSigmaHP = CreateLabel("Допускаемое контактное напряжение σHP(мПа):", 20, 140);
            txtSigmaHP = CreateTextBox(400, 140);
            toolTip.SetToolTip(txtSigmaHP, "Введите допустимое контактное напряжение");

            var labelEfficiency = CreateLabel("Коэффициент полезного действия передачи n:", 20, 180);
            txtEfficiency = CreateTextBox(400, 180);
            toolTip.SetToolTip(txtEfficiency, "Введите коэффициент полезного действия");

            var labelPowerN1 = CreateLabel("Мощность на валу N1 (кВт):", 20, 220);
            txtPowerN1 = CreateTextBox(400, 220);
            toolTip.SetToolTip(txtPowerN1, "Введите мощность на валу");

            /*var labelMaterial = CreateLabel("Название материала:", 20, 260);
            txtMaterial = CreateTextBox(400, 260);
            toolTip.SetToolTip(txtMaterial, "Введите название материала");*/
            var labelMaterial = CreateLabel("Материал:", 20, 260);
            cmbMat = CreateComboBox(400, 260, materials);
            toolTip.SetToolTip(cmbMat, "Выберите материал");

            var labelSigmaFP = CreateLabel("Предел прочности материала σFP:", 20, 300);
            txtSigmaFP = CreateTextBox(400, 300);
            toolTip.SetToolTip(txtSigmaFP, "Введите предел прочности материала");
            
            
            
            var labelCycleTime = CreateLabel("Время эквивалентного числа циклов  Tч:", 20, 340);
            eqCycleTime = CreateTextBox(400, 340);
            toolTip.SetToolTip(eqCycleTime, "Время эквивалентного числа циклов  Tч");
            


            groupBoxInput.Controls.AddRange(new Control[]
            {
                labelZ2, cmbZ2, labelZ1, cmbZ1, labelQ, txtQ, labelSigmaHP, txtSigmaHP,
                labelEfficiency, txtEfficiency, labelPowerN1, txtPowerN1,
                labelSigmaFP, txtSigmaFP, cmbMat, labelMaterial, labelCycleTime, eqCycleTime
            });

            // Результаты расчётов
            var groupBoxResults = CreateGroupBox("Результаты расчётов", 20, 440, 600, 300);

            var labelAW = CreateLabel("Межосевое расстояние aw:", 20, 30);
            txtAW = CreateTextBox(400, 20, true);

            var labelD2 = CreateLabel("Делительный диаметр колеса d2:", 20, 70);
            txtD2 = CreateTextBox(400, 60, true);

            var labelX = CreateLabel("Коэффициент смещения x:", 20, 110);
            txtX = CreateTextBox(400, 100, true);

            var labelM = CreateLabel("Модуль по изгибу m:", 20, 150);
            txtM = CreateTextBox(400, 140, true);

            groupBoxResults.Controls.AddRange(new Control[]
            {
                labelAW, txtAW, labelD2, txtD2, labelX, txtX, labelM, txtM
            });

            // Кнопка расчёта
            btnCalculate = new Button
            {
                Text = "Рассчитать",
                Location = new Point(20, 400),
                Size = new Size(150, 40),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCalculate.Click += BtnCalculate_Click;

            // Добавление элементов управления на форму
            this.Controls.Add(groupBoxInput);
            this.Controls.Add(groupBoxResults);
            this.Controls.Add(btnCalculate);
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                var n0 = 0.73;
                var n3 = 0.78;
                var np = 0.84;
                var nv = 0.9;
                //var z2Values = new List<Double>(){ 20, 24, 26, 28, 30, 32, 35, 37, 40, 45, 50, 60, 80, 100, 150 };
                var YfValues = new List<double> { 1.98, 1.88, 1.85, 1.8, 1.76, 1.71, 1.64, 1.61, 1.55, 1.48, 1.45, 1.4, 1.34, 1.3, 1.27 };
                var nValues = new List<double> { 0.73, 0.78, 0.84, 0.90 };
                //var z1Values = new List<int>() { 1, 2, 3, 4 };
                
                // Считывание данных
                int z2 = ValidateIntInput(cmbZ2, "Количество зубьев червячного колеса z2");
                int z1 = ValidateIntInput(cmbZ1, "Число витков червяка z1");
                double q = ValidateDoubleInput(txtQ, "Передаточное число q");
                double sigmaHP = ValidateDoubleInput(txtSigmaHP, "Допускаемое контактное напряжение σHP");
                double Nefficiency = ValidateDoubleInput(txtEfficiency, "Коэффициент полезного действия передачи n");
                double powerN1 = ValidateDoubleInput(txtPowerN1, "Мощность на валу N1");
                double sigmaFP = ValidateDoubleInput(txtSigmaFP, "Предел прочности материала σFP");
                string material = ValidateMaterialInput(cmbMat, "Материал", materials);
                var t = ValidateIntInput(eqCycleTime, "Время квивалентного числа циклов t");

                var Yf = YfValues[z2Values.IndexOf(z2)];
                var n = nValues[z1Values.IndexOf(z1)];
                var n2 = CalculateN2(n, n0, n3, np, nv);
                var T2_i = CalculateT2(powerN1, Nefficiency, n2);
                var d2 = CalculateD2(T2_i, z2, sigmaHP, q);
                var aw = CalculateAw(z2, q, T2_i, sigmaHP);
                var m = CalculateModule(Yf, T2_i, z2, q, sigmaFP);
                var x = CalculateX(aw, m, q, z2);
                double kfl = 0;
                
                var rand = new Random();
                switch (material)
                {
                    case "бронза":
                        case "латунь":
                            kfl = rand.NextDouble(0.54, 1);
                            break;
                    case "чугун":
                        kfl = 1;
                        break;
                }

                // Вывод результатов
                txtAW.Text = aw.ToString("F2");
                txtD2.Text = d2.ToString("F2");
                txtX.Text = x.ToString("F2");
                txtM.Text = m.ToString("F2");
                
                
                

                using (var database = new DbManager())
                {
                    var detail = new Detail
                    {
                        Aw = aw,
                        Kfl = kfl,
                        M = m,
                        N = n,
                        N1 = powerN1,
                        SigmaHP = sigmaHP,
                        Z2 = z2,
                        Z1 = z1,
                        X = x,
                        T2 = T2_i
                    };

                    var constructionUnit = new ConstructionUnit
                    {
                        Aw = aw,
                        Kfl = kfl,
                        N = n,
                        X = x
                    };
                    
                    database.ConstructionUnits.Add(constructionUnit);
                    database.Details.Add(detail);
                    database.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private GroupBox CreateGroupBox(string text, int x, int y, int width, int height)
        {
            return new GroupBox
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height),
                Font = new Font("Segoe UI", 10),
                Padding = new Padding(10)
            };
        }

        private Label CreateLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
        }

        private TextBox CreateTextBox(int x, int y, bool readOnly = false)
        {
            return new TextBox
            {
                Location = new Point(x, y),
                Width = 200,
                ReadOnly = readOnly,
                Font = new Font("Segoe UI", 10),
                BorderStyle = BorderStyle.FixedSingle
            };
        }
        private ComboBox CreateComboBox(int x, int y, List<int> values)
        {
            var comboBox = new ComboBox
            {
                Location = new Point(x, y),
                Width = 200,
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDown // Позволяет вводить вручную
            };

            // Добавляем значения в ComboBox
            foreach (var value in values)
            {
                comboBox.Items.Add(value);
            }

            return comboBox;
        }
        private ComboBox CreateComboBox(int x, int y, List<double> values)
        {
            var comboBox = new ComboBox
            {
                Location = new Point(x, y),
                Width = 200,
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDown // Позволяет вводить вручную
            };

            // Добавляем значения в ComboBox
            foreach (var value in values)
            {
                comboBox.Items.Add(value);
            }

            return comboBox;
        }
        
        private ComboBox CreateComboBox(int x, int y, List<string> values)
        {
            var comboBox = new ComboBox
            {
                Location = new Point(x, y),
                Width = 200,
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDown // Позволяет вводить вручную
            };

            // Добавляем значения в ComboBox
            foreach (var value in values)
            {
                comboBox.Items.Add(value);
            }

            return comboBox;
        }

        
        private double CalculateAw(int z2, double q, double T2_i, double sigmaHP)
        {
            return (z2 + q) * Math.Sqrt((3.4 * 1e7 * T2_i) / Math.Pow((sigmaHP * z2), 2) * q);
        }

        private double CalculateT2(double N1, double eta, double n2)
        {
            return 9.0 * 1e3 * N1 * eta / n2;
        }

        private double CalculateN2(double n, double n0, double n3, double np, double nv)
        {
            return n / (n0 * n3 * np * nv);
        }

        private double CalculateModule(double Yf, double T2_i, int z2, double q, double sigmaFP)
        {
            return 12.5 * Math.Pow((Yf * T2_i) / (z2 * q * sigmaFP), 1.0 / 3.0); //wrong
        }

        private double CalculateD2(double T2_i, int z2, double sigmaHP, double q)
        {
            return 640 * Math.Pow((T2_i * z2 / (sigmaHP * q)), 1.0 / 3.0);
        }

        private double CalculateX(double aw, double m, double q, int z2)
        {
            return (aw / m) - 0.5 * (q + z2);
        }

        private int ValidateIntInput(TextBox txtBox, string fieldName)
        {
            try
            {
                return int.Parse(txtBox.Text);
            }
            catch (FormatException)
            {
                throw new ArgumentException($"Ошибка ввода в поле '{fieldName}': введите корректное целое число.");
            }
        }

        private int ValidateIntInput(ComboBox comboBox, string fieldName)
        {
            try
            {
                // Проверяем, выбрано ли значение или введено вручную
                if (int.TryParse(comboBox.Text, out int result))
                {
                    return result;
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                throw new ArgumentException($"Ошибка ввода в поле '{fieldName}': введите корректное целое число.");
            }
        }
        
        private double ValidateDoubleInput(TextBox txtBox, string fieldName)
        {
            try
            {
                return double.Parse(txtBox.Text);
            }
            catch (FormatException)
            {
                throw new ArgumentException($"Ошибка ввода в поле '{fieldName}': введите корректное число с плавающей точкой.");
            }
        }
        private string ValidateMaterialInput(ComboBox comboBox, string fieldName, List<string> validMaterials)
        {
            try
            {
                string selectedMaterial = comboBox.Text.Trim().ToLower(); // Убираем лишние пробелы и приводим к нижнему регистру
                if (validMaterials.Contains(selectedMaterial))
                {
                    return selectedMaterial;
                }
                else
                {
                    throw new ArgumentException($"Ошибка ввода в поле '{fieldName}': выберите материал из списка.");
                }
            }
            catch (Exception)
            {
                throw new ArgumentException($"Ошибка ввода в поле '{fieldName}': выберите материал из списка.");
            }
        }
        
        

    }
    