﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace TestDrive.Views
{
	public class Veiculo
	{
		public string nome { get; set; }
		public decimal preco { get; set; }
		public string PrecoFormatado
		{
			get
			{
				return string.Format("R$ {0}", preco);
			}
		}

		public FormattedString VeiculoLabel
		{
			get
			{
				return new FormattedString
				{
					Spans = {
						new Span { Text = nome },
						new Span { Text = " - " },
						new Span { Text = PrecoFormatado, FontAttributes = FontAttributes.Bold } }
				};
			}
			set { }
		}
	}

    public class Weather{
        public string temp { get; set; }
        public string imgurl { get; set; } = "http://openweathermap.org/img/w/";

    }


	public partial class CarList : ContentPage
	{

        public List<Veiculo> Veiculos { get; set; }

        public CarList()
		{
			InitializeComponent();

			this.Veiculos = new List<Veiculo>()
			{
				new Veiculo { nome = "Azera V6", preco = 85000 },
				new Veiculo { nome = "Onix 1.6", preco = 35000 },
				new Veiculo { nome = "Fiesta 2.0", preco = 52000 },
				new Veiculo { nome = "C3 1.0", preco = 22000 },
				new Veiculo { nome = "Uno Fire", preco = 11000 },
				new Veiculo { nome = "Sentra 2.0", preco = 53000 },
				new Veiculo { nome = "Astra Sedan", preco = 39000 },
				new Veiculo { nome = "Vectra 2.0 Turbo", preco = 37000 },
				new Veiculo { nome = "Hilux 4x4", preco = 90000 },
				new Veiculo { nome = "Montana Cabine dupla", preco = 57000 },
				new Veiculo { nome = "Outlander 2.4", preco = 99000 },
				new Veiculo { nome = "Brasilia Amarela", preco = 9500 },
				new Veiculo { nome = "Omega Hatch", preco = 8000 }
			};

			this.BindingContext = this;
		}

        private async void getJson(){
			{
				var httpRequest = new HttpClient();
				var stream = await httpRequest.GetStringAsync("https://openweathermap.org/data/2.5/weather?id=3448439&appid=b1b15e88fa797225412429c1c50c122a1");

                var json = JsonConvert.DeserializeObject(stream);
                System.Diagnostics.Debug.WriteLine(json);
                //foreach (var item in carrosDes)
				//{
				//	Produto produto = new Produto()
				//	{
				//		Id = int.Parse(item.Attribute("id").Value),
				//		Descricao = item.Element("descricao").Value,
				//		Categoria = item.Element("categoria").Value,
				//		Quantidade = int.Parse(item.Element("quantidade").Value),
				//		Preco = decimal.Parse(item.Element("precounitario").Value)
				//	};
				//	produtos.Add(produto);
				//}
				//lstProduto.ItemsSource = produtos;
			}
        }

		void TestClick(object sender, System.EventArgs e)
		{
            this.getJson();
		}

		private void listViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var veiculo = (Veiculo)e.Item;

            Navigation.PushAsync(new CarDetail(veiculo));
		}
	}
}