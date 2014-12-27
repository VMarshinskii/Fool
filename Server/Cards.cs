using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoolService
{
    public class Deck
    {
        // массив из 36 карт
        public List<int> cards = new List<int>(36);

        public int trump;

        // Задаем колоду карт по типу 1-"6", 2-"7", 3-"8", 4-"9", 5-"10", 6-"В", 7-"Д", 8-"К", 9-"Т"
        // Масть задается первой цифрой двухзначного числа 1-"Буби", 2-"Крести", 3-"Пики", 4-"Червы"
        public Deck()
        {
            // записываем в колоду все карты
            for (int i = 11; i < 19; i++)
            {
                cards.Add(i);
            }
            for (int i = 21; i < 29; i++)
            {
                cards.Add(i);
            }
            for (int i = 31; i < 39; i++)
            {
                cards.Add(i);
            }
            for (int i = 41; i < 49; i++)
            {
                cards.Add(i);
            }

            mix();

            // Выбираем козырь.
            trump = cards[35] % 10;
        }

        // ф-я перемешивания
        public void mix()
        {
            Random random = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                int value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        public bool CompareCards(int cardA, int cardB)
        {
            int A = cardA % 10;
            int B = cardB % 10;
            // Проверка совпадения масти
            if (A == B)
            {
                if (cardA > cardB)
                    return true;
                return false;
            }
            // Если масть козырная, то прибавим ей значение
            if (A == trump)
                cardA += 40;
            if (B == trump)
                cardB += 40;
            if (cardA > cardB)
                return true;
            return false;
        }
    }

    
}