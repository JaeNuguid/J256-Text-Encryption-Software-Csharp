using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
* The Sub_Encryption class contains the shifting algorithm 
* and key generation for J256's encryption.
*
* @author  Jae Allen Reyes Nuguid
* @version 1.0
* @since   01-09-2017 
*/


namespace J256
{
    class Sub_Encryption
    {


        public int key = 0, key0 = 0;
	char[] j;


        //Function: Encryption
        //Genearates a key, encrypts the semi-encrypted J256, returns a String(encrypted text).
        public char[] Encryption(char[] x)
        {
            this.j = x;

            key = generateKey();


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
                if (j[x] >= '0' && j[x] <= '9')
                {
                    for (int y = 0; y < key0; y++)
                    {
                        j[x]++;
                        if (j[x] > '9') j[x] = '0';

                    }
                    key0++;
                }
                else if (j[x] >= 'A' && j[x] <= 'Z')
                {
                    for (int y = 0; y < key0; y++)
                    {
                        j[x]++;

                        if (j[x] > 'Z') j[x] = 'A';

                    }
                    key0++;
                }
                else if (j[x] >= 'a' && j[x] <= 'z')
                {

                    for (int y = 0; y < key0; y++)
                    {

                        j[x]++;
                        if (j[x] > 'z') j[x] = 'a';
                    }
                    key0++;
                }
                else if (j[x] == ' ')
                {
                    j[x] = '\\';
                    key0++;
                }

                if (key0 > 9) key0 = 0;
            }
        }

        //Function: generateKey
        //Generates and returns an integer ranging from 32 to 256.
        public int generateKey()
        {
            Random r = new Random();
            return r.Next(32,256);

        }

    }
}
