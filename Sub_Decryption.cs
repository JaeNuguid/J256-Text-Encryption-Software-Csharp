using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* The Sub_Encryption class contains the reverse
* shifting algorithm for J256's encryption.
*
* @author  Jae Allen Reyes Nuguid
* @version 1.0
* @since   01-09-2017 
*/
namespace J256
{
    class Sub_Decryption
    {
        int key = 0, key0 = 0;
	char[] x;

        //Function: Decryption
        //Decrypts the text and returns a String.
        public char[] Decryption(int key, char[] x)
        {
            this.x = x;
            this.key = key;


            for (int z = 0; z < key; z++)
            {
                jShifter(x);
            }

            return x;
        }

        //Function: jShifter
        //Shifts the characters to its corresponding number of loop.
        public void jShifter(char[] p)
        {
            for (int x = 0; x < p.Length; x++)
            {
                if (p[x] >= '0' && p[x] <= '9')
                {
                    for (int y = 0; y < key0; y++)
                    {
                        p[x]--;
                        if (p[x] < '0') p[x] = '9';

                    }
                    key0++;
                }
                else if (p[x] >= 'A' && p[x] <= 'Z')
                {
                    for (int y = 0; y < key0; y++)
                    {
                        p[x]--;
                        if (p[x] < 'A') p[x] = 'Z';

                    }
                    key0++;
                }
                else if (p[x] >= 'a' && p[x] <= 'z')
                {

                    for (int y = 0; y < key0; y++)
                    {

                        p[x]--;

                        if (p[x] < 'a') p[x] = 'z';
                    }
                    key0++;
                }
                else if (p[x] == '\\')
                {
                    p[x] = ' ';
                    key0++;
                }

                if (key0 > 9) key0 = 0;


            }
        }
    }
}
