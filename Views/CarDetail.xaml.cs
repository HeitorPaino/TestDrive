using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TestDrive.Views
{
	public partial class CarDetail : ContentPage
	{
		public Veiculo Veiculo { get; set; }

        public CarDetail(Veiculo veiculo)
		{
			this.Veiculo = veiculo;
			InitializeComponent();
			this.BindingContext = this;
		}

		private void botaoProximo_Clicked(object sender, EventArgs e)
		{
            Navigation.PopAsync();
		}
	}
}
