using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WebServices.WindowsClient
{
	public partial class Form1 : Form
	{
		
		public Form1()
		{
			InitializeComponent();
		}

		void CalulateFibonacci()
		{

			var output = Helpers.InvokeFibonacciService(10);
			MessageBox.Show($"Fibonacci de 10 est :{output}");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (WaitForm form = new WaitForm(CalulateFibonacci))
			{
				form.ShowDialog(this);
			}
		}
	}
}
