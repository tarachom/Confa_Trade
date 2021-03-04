using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AccountingSoftware;
using Конфа = НоваКонфігурація_1_0;
using Константи = НоваКонфігурація_1_0.Константи;
using Довідники = НоваКонфігурація_1_0.Довідники;

namespace Confa_Trade
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			string pathToConfa = @"D:\AcoountigConfig\ConfaTrade\Confa.xml";

			Exception exception = null;

			Конфа.Config.Kernel = new Kernel();

			bool flag = Конфа.Config.Kernel.Open2(pathToConfa,
					"localhost",
					"postgres",
					"525491",
					5432,
					"confa_trade", out exception);

			Довідники.Тест_Objest тест_Objest = new Довідники.Тест_Objest();
			тест_Objest.New();
			тест_Objest.Назва = "Tesat";
			тест_Objest.Код = "0001";
			тест_Objest.Save();

			Довідники.Тест2_Objest тест2_Objest = new Довідники.Тест2_Objest();
			тест2_Objest.New();
			тест2_Objest.ТестІд = тест_Objest.GetDirectoryPointer();
			тест2_Objest.Назва = "fsdfs";
			тест2_Objest.Код = "444";
			тест2_Objest.Save();

		}
	}
}
