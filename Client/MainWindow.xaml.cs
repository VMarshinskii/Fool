using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
﻿using Client.ServiceReference1;

namespace Client
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private FoolServiceClient client = new FoolServiceClient();

		private int MyUserId;
		private Grid SelectCard;
		private void Update()
		{
			// получаем карты, обновляем их на столе
			Dictionary<int, int> CardOnTable = client.GetCardsOnTable();
			//######### TODO тут нужно обновить каты на столе
			//View_UpdateCardOnTable(CardOnTable);

			// получаем всех юзеров и обновляем их статусы
			List<User> AllUsers = client.GetAllUsersOnTable().ToList();
			// ######### TODO тут нужно обновить статусы всех юзеров
			//View_UpdateStatusUsers(AllUsers); ######## Протестируйте в работе, может понадобиться работа с ссылками.

			// тут работаем со своим юзером
			User MyUser = AllUsers[MyUserId];
			List<int> MyCards = MyUser.cards.ToList();
			// ######### TODO тут нужно обновить карты своего юзера
			//View_UpdateCardsMain(MyCards);

			int MyStatus = MyUser.status;

			// ######### тут в зависимости от статуса либо ожидание либо дается возможность выполнения какого-то действия
			switch (MyStatus)
			{
				case 0:
					//ожидание
					break;
				case 1:
					//ходи
					break;
				default:
					break;
			}

		}

		public MainWindow()
		{
			InitializeComponent();
			List<int> lstMain = new List<int>(){11, 23, 45, 32, 12, 13};
			Dictionary<int, int> dictCardOnTable = new Dictionary<int, int>();
			dictCardOnTable.Add(15,16);
			dictCardOnTable.Add(26, 0);
			dictCardOnTable.Add(18, 0);
			dictCardOnTable.Add(43, 44);
			View_UpdateCardsMain(lstMain);
			View_UpdateCardsOnTable(dictCardOnTable);
			
			//User user = client.Registration("Вяся");
		}

		private void View_UpdateCardsMain(List<int> cards)
		{
			stpCardsMain.Children.Clear();
			cards.Sort();
			foreach (int id in cards)
			{
				Grid g = new Grid();
				Border bb = new Border
				{
					BorderBrush = Brushes.RoyalBlue,
					BorderThickness = new Thickness(1),
					Opacity = 0,
					Margin = new Thickness(1, 2, 2, 1)
				};
				Border br = new Border
				{
					BorderBrush = Brushes.Red,
					BorderThickness = new Thickness(1),
					Opacity = 0,
					Margin = new Thickness(1, 2, 2, 1)
				};

				g.PreviewMouseDown += CardSelect;
				g.MouseEnter += CardEnter;
				g.MouseLeave += CardLeave;

				Image img = new Image();
				img.AllowDrop = true;
				img.Source = new BitmapImage(new Uri("pack://application:,,,/img/" + id + ".png"));
				img.Margin = new Thickness(2);
				g.Tag = id;

				g.Children.Add(img);
				g.Children.Add(bb);
				g.Children.Add(br);

				stpCardsMain.Children.Add(g);
			}
		}
		private void View_UpdateCardsIn(List<int> cards)
		{
			stpCardsIn.Children.Clear();
			foreach (int id in cards)
			{
				Image img = new Image();
				img.AllowDrop = true;
				img.Source = new BitmapImage(new Uri("pack://application:,,,/img/" + id + ".png"));
				img.Margin = new Thickness(2);
				img.Tag = id;
				stpCardsIn.Children.Add(img);
			}
		}
		private void View_UpdateCardsOut(List<int> cards)
		{
			stpCardsOut.Children.Clear();
			int i = 0;
			foreach (int id in cards)
			{
				Grid g = new Grid();
				Border bb = new Border
				{
					BorderBrush = Brushes.RoyalBlue,
					BorderThickness = new Thickness(1),
					Opacity = 0,
					Margin = new Thickness(1, 2, 2, 1)
				};
				
				g.PreviewMouseDown += CardBatle;
				g.MouseEnter += CardEnter;
				g.MouseLeave += CardLeave;

				Image img = new Image();
				img.AllowDrop = true;
				img.Source = new BitmapImage(new Uri("pack://application:,,,/img/" + id + ".png"));
				img.Margin = new Thickness(2);
				g.Tag = new int[] {id, i++};

				g.Children.Add(img);
				g.Children.Add(bb);

				stpCardsOut.Children.Add(g);
			}
		}
		private void View_UpdateCardsOnTable(Dictionary<int, int> cards)
		{
			List<int> cardsIn = cards.Keys.ToList();
			List<int> cardsOut = cards.Values.ToList();
			View_UpdateCardsIn(cardsIn);
			View_UpdateCardsOut(cardsOut);
		}

		private void View_UpdateStatusUsers(List<User> allUsers)
		{
			int vbxId = 0;
			Viewbox[] vbx = {vbxTopUser, vbxLeftUser, vbxRightUser, vbxLeftTopUser, vbxRightTopUser};
			foreach (User user in allUsers)
			{
				if (user.id != MyUserId)
				{
					View_UpdateStatusUser(user,ref vbx[vbxId]);
				}
			}
		}

		private void View_UpdateStatusUser(User user,ref  Viewbox vbxUser)
		{
			StackPanel stp = new StackPanel(){};
			Label lblName = new Label(){Content = user.name};
			Label lblStatus = new Label() { Content = user.status };
			Label lblCards = new Label() { Content = user.cards };
			stp.Children.Add(lblName);
			stp.Children.Add(lblStatus);
			stp.Children.Add(lblCards);
			vbxUser.Child = stp;
		}

		//########## Метод отправки карт для сравнения.
		private void CardBatle(object sender, MouseButtonEventArgs e) 
		{
			if (SelectCard != null)
			{
				Grid g = sender as Grid;
				int[] tag = (int[]) g.Tag;
				int index = tag[1];
				Grid gIn = stpCardsIn.Children[index] as Grid;

				//Получаем id карт. cardA - выбраная карта для отбивания, cardB - карта, которую отбивают. 
				int cardA = (int) SelectCard.Tag;
				int cardB = (int)gIn.Tag;

				//Отчищаем память от выбранной катры 
				Border bb = SelectCard.Children[1] as Border;
				Border br = SelectCard.Children[2] as Border;
				bb.Opacity = 0;
				br.Opacity = 0;
				SelectCard = null;
				
				//##### TODO Сдесь вызов метода отправки пары карт на проверку "бито не бито"
			}
		}

		private void CardLeave(object sender, MouseEventArgs e)
		{
			Grid g = sender as Grid;
			Border bb = g.Children[1] as Border;
			bb.Opacity = 0;
		}

		private void CardEnter(object sender, MouseEventArgs e)
		{
			Grid g = sender as Grid;
			Border bb = g.Children[1] as Border;
			bb.Opacity = 0.5;
		}

		private void CardSelect(object sender, MouseButtonEventArgs e)
		{
			Grid g = sender as Grid;
			if (g == SelectCard || SelectCard == null)
			{
				Border bb = g.Children[1] as Border;
				Border br = g.Children[2] as Border;

				if (br.Opacity != 0.5)
				{
					bb.Opacity = 0;
					br.Opacity = 0.5;
					SelectCard = g;
				}
				else
				{
					bb.Opacity = 0.5;
					br.Opacity = 0;
					SelectCard = null;
				}
			}
		}
	}
}
