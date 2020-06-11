using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fighterjetshooting
{
    public class Scoreboard
    {
        private string[] names;
        private int[] scores;
        
        public Scoreboard()
        {
            names = new string[6];
            scores = new int[6];
            for (int i = 0; i < 6; i++)
            {
                names[i] = "";
                scores[i] = 0;
            }
        }

        
        public string[] BubbleSort(string[] arr)
        {
            int temp;
            string temp_player;
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                if (j % 2 == 0)
                {
                    continue;
                }
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (i % 2 == 0)
                    {
                        continue;
                    }
                    if (Convert.ToInt32(arr[i]) < Convert.ToInt32(arr[i + 2]))
                    {
                        temp = Convert.ToInt32(arr[i + 2]);
                        temp_player = arr[i + 1];
                        arr[i + 1] = arr[i - 1];
                        arr[i - 1] = temp_player;
                        arr[i + 2] = Convert.ToString(arr[i]);
                        arr[i] = Convert.ToString(temp);
                    }
                }
            }
            return arr;
        }

        public int this[int index]
        {
            get => scores[index];
            set => scores[index] = value;
        }

        public int GetScore(int index)
        {
            return scores[index];
        }

        public void SetScore(int index, int value)
        {
            scores[index] = value;
        }
    }
}
