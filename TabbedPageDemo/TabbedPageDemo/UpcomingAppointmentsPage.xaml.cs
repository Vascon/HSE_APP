using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using HSE_APP;
using System.Net.Http;
using Newtonsoft.Json;

namespace HSE_APP
{
	public partial class UpcomingAppointmentsPage : ContentPage
	{

		public class Status
		{
			public string message { get; set; }
			public int value { get; set; }
		}

		public class Example
		{
			public Status status { get; set; }
		}






		//Post запрос на просмотр информации об ивенте
		async void Event_Description_PostRequest(string URL)
		{
			try{
				//создаем пару key/value
				var formContent = new FormUrlEncodedContent(new[]
					{
						new KeyValuePair<string, string>("event", ListViewID.Value.ToString()), 
					});

				var myHttpClient = new HttpClient();
				var response = await myHttpClient.PostAsync(URL, formContent);

				var json = await response.Content.ReadAsStringAsync();
				Events_Description res = JsonConvert.DeserializeObject<Events_Description>(json);


				Event_name.Text = res.events [0].name;
				Event_picture.ScaleTo (0.7);
				Event_picture.Source = res.events [0].picture;
				Event_place.Text = res.events [0].place;
				Event_time.Text = res.events [0].time;
				Event_description.Text = res.events [0].description;
			}
			catch (System.Net.WebException){
			}
		}

		//запрос на просмотр участников
		async void Event_Participants_PostRequest(string URL)
		{
			try{
				//создаем пару key/value
				var formContent = new FormUrlEncodedContent(new[]
					{
						new KeyValuePair<string, string>("event", ListViewID.Value.ToString()), 
					});

				var myHttpClient = new HttpClient();
				var response = await myHttpClient.PostAsync(URL, formContent);

				var json = await response.Content.ReadAsStringAsync();
				Participants res = JsonConvert.DeserializeObject<Participants>(json);
				if (res.events.Count==0)
					Event_participants.Text = "Пока нет ни одного участника";
				else 
				{
					Event_participants.Text = "Участники: \n";
					for (int i = 0; i < res.events.Count; i++) 
					{
						Event_participants.Text += res.events [i].name;
						if (i!=res.events.Count-1)
							Event_participants.Text += ",";
					}
				}
			}
			catch (System.Net.WebException){
			}
		}

		static string GetRandomPassword(int pwdLength)
		{
			string ch="1234567890abcdefg";
			Random rndGen = new Random ();
			char[] pwd = new char[pwdLength];
			for (int i = 0; i < pwd.Length; i++)
				pwd[i] = ch[rndGen.Next(ch.Length)];     
			return new string(pwd);
		}


		//Регистрация
		async void Add_Player_PostRequest()

		{
			try
			{
				//создаем пары key/value
				var postData = new List<KeyValuePair<string, string>>();
				postData.Add(new KeyValuePair<string, string>("name", myName.Text));
				postData.Add(new KeyValuePair<string, string>("num_group", myGroup.Text));
				postData.Add(new KeyValuePair<string, string>("login",  GetRandomPassword(5)));
				postData.Add(new KeyValuePair<string, string>("password",GetRandomPassword(5)));

				var formContent = new FormUrlEncodedContent(postData);

				var myHttpClient = new HttpClient();
				var response = await myHttpClient.PostAsync("http://52.34.210.167:80/insert_player", formContent);
				var json = await response.Content.ReadAsStringAsync();
				PlayerID res = JsonConvert.DeserializeObject<PlayerID>(json);

				ListViewID.Participant_ID = res.id;
				Add_Participants_PostRequest ();
			}
			catch (System.Net.WebException){
			}

			//var json = await response.Content.ReadAsStringAsync();

		}

		async void Add_Participants_PostRequest()
		{
			try{
				//создаем пары key/value
				var formContent = new FormUrlEncodedContent(new[]
					{
						new KeyValuePair<string, string>("event", ListViewID.Value.ToString()), 
						new KeyValuePair<string, string>("player", ListViewID.Participant_ID), 

					});
				var myHttpClient = new HttpClient();
				await myHttpClient.PostAsync("http://52.34.210.167:80/insert_participant", formContent);
				Event_Participants_PostRequest ("http://52.34.210.167:80/select_participants_of_event");
				//var json = await response.Content.ReadAsStringAsync();
			}
			catch (System.Net.WebException){
			}

		}




		public UpcomingAppointmentsPage ()
		{
			InitializeComponent ();
			//отправляем Post запрос для получение информации о выбранном мероприятии
			Event_Description_PostRequest ("http://52.34.210.167:80/select_event_with_picture");
			Event_Participants_PostRequest ("http://52.34.210.167:80/select_participants_of_event");
			//Event_participants.Text += "123,123,123,123,123";
		}
		//http://52.34.210.167/select_participants_of_event

		//Кнопка назад
		async void OnBackButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PopModalAsync ();
		}

		//кнопка регистрации
		async void OnRegisterButtonClicked (object sender, EventArgs e)
		{
			if (myName.Text == "")
				await DisplayAlert ("Введите своё имя", "", "Ok");
			else
				Add_Player_PostRequest (
				);
			myName.Text = "";
			myGroup.Text = "";



			//Event_participants.Text += "КОЛЯ!!! ";
			/*Зарегать пользователя на мероприятие*/
			//await Navigation.PopModalAsync ();
		} 
	}
}

