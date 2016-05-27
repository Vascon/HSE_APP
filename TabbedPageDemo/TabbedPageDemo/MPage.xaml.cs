using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Collections;

namespace HSE_APP
{
	public partial class MPage
	{

		//запрос для показа списка ивентов
		async void showEvents_Request(string URL)
		{
			try
			{
				using (var httpClient = new HttpClient())
				{
					var json = await httpClient.GetStringAsync(URL);
					Events currEvents = JsonConvert.DeserializeObject<Events>(json);
					ListView1.ItemsSource = currEvents.events;
				}
			}
			catch (System.Net.WebException){
				await DisplayAlert ("Нет связи с сервером", "", "Ok");
			}
		}

		//запрос для показа списка игр
		async void showGames_Request(string URL)
		{
			try
			{
				using (var httpClient = new HttpClient())
				{
					var json = await httpClient.GetStringAsync(URL);
					Games currEvents = JsonConvert.DeserializeObject<Games>(json);
					ListView2.ItemsSource = currEvents.games;
				}
			}
			catch (System.Net.WebException){
				await DisplayAlert ("Нет связи с сервером", "", "Ok");
			}
		}

		//Действия при инициализации страницы
		public MPage()
		{
			InitializeComponent();
			//ListView1.IsPullToRefreshEnabled = true;
			showEvents_Request ("http://52.34.210.167:80/select_events");
			showGames_Request ("http://52.34.210.167/select_games_with_picture");
		}

		//действие по тапу на элекмент ListView
		async void MyTap(object sender, ItemTappedEventArgs e)
		{
			ListViewID.Value = ((Event)e.Item).id;
			//await DisplayAlert ("Item Tapped", ((Event)e.SelectedItem).id, "Ok");
			var modalPage = new HSE_APP.UpcomingAppointmentsPage ();
			await Navigation.PushModalAsync (modalPage);
		}

		//Действие при выборе игры
		async void ItemSelected_Game(object sender, SelectedItemChangedEventArgs e)
		{
			ListViewID.Value_Game = ((Game)e.SelectedItem).name;
		}


		/*async void OnLoginButtonClicked (object sender, EventArgs e)
		{
			LoginPassword.Login = email_label.Text;
			LoginPassword.Password = password_label.Text;
		} */

		//Запрос на добавление ивента
		async void Add_Event_PostRequest()
		{
			try
			{
				//создаем пары key/value
				var postData = new List<KeyValuePair<string, string>>();
				postData.Add(new KeyValuePair<string, string>("game", ListViewID.Value_Game));
				postData.Add(new KeyValuePair<string, string>("time", event_Time.Text));
				postData.Add(new KeyValuePair<string, string>("place",  event_Place.Text));

				var formContent = new FormUrlEncodedContent(postData);

				var myHttpClient = new HttpClient();

				var response = await myHttpClient.PostAsync("http://52.34.210.167:80/insert_event", formContent);

				var json = await response.Content.ReadAsStringAsync();
				PlayerID res = JsonConvert.DeserializeObject<PlayerID>(json);
				if (res.error == true) {
					await DisplayAlert ("Ошибка добавления", "", "Ok");
				} 
				else 
				{
					event_Time.Text="";
					event_Place.Text="";
				}

				showEvents_Request ("http://52.34.210.167:80/select_events");
			}
			catch (System.Net.WebException){
			}
		}

		//проверка корректности введённого времени
		bool correctTime(string time)
		{
			if (time.Length == 19 && time [4] == '-' && time [7] == '-' && time [10] == ' ' && time [13] == ':' && time [16] == ':' && time [0] == '2' && time [1] == '0')
				return true;
			else
				return false;
		}

		//действия по нажатию на кнопку "создать"
		async void create_Event_Button(object sender, EventArgs e)
		{
			if (ListViewID.Value_Game == null)
				await DisplayAlert ("Сперва выберете игру", "", "Ok");
			else
			{
				switch (ListViewID.Value_Game)
				{
				case "Мафия":
					ListViewID.Value_Game = "14";
					break;
				case "Манчкин":
					ListViewID.Value_Game = "15";
					break;
				case "Имаджинариум":
					ListViewID.Value_Game = "16";
					break;
				case "Игросказ":
					ListViewID.Value_Game = "17";
					break;
				case "Элиас":
					ListViewID.Value_Game = "18";
					break;
				case "Активити":
					ListViewID.Value_Game = "19";
					break;
				case "Magic: The Gathering":
					ListViewID.Value_Game = "20";
					break;
				case "Гномы-вредители":
					ListViewID.Value_Game = "21";
					break;
				case "Дженга":
					ListViewID.Value_Game = "22";
					break;
				case "Экивоки":
					ListViewID.Value_Game = "23";
					break;
				case "Каркассон":
					ListViewID.Value_Game = "24";
					break;
				case "Монополия":
					ListViewID.Value_Game = "25";
					break;
				case "Уно":
					ListViewID.Value_Game = "26";
					break;
				}
				if (correctTime(event_Time.Text)==false)
					await DisplayAlert ("Время некорректно", "", "Ok");
				else
					Add_Event_PostRequest ();
			}

		}



	}
}
