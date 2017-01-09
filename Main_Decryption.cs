using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
* The Main_Decryption class contains the main algorithm 
* for J256's decryption.
*
* @author  Jae Allen Reyes Nuguid
* @version 1.0
* @since   01-09-2017 
*/

namespace J256
{
    class Main_Decryption
    {

        // Initial set of characters
        char[] Zs = {'|','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d','e',
            'f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',' ',',','.',
            '0','1','2','3','4','5','6','7','8','9','!','@','#','$','%','^','&','*','(',')','_','+','-','=','/'
            ,'`','~',':',';','"','\'','<','>','?','/'};


        //Function: Decryption
        //Decrypts a J256 using permutation and combination techniques. Outputs a String(decrypted text).	
        public String Decryption(String x)
        {

            Sub_Decryption sd = new Sub_Decryption();
            char[] dec = x.ToCharArray();
            int j = x.IndexOf("|J|");
            String jj = "", bb = "";
            for (int o = 0; o < j; o++)
            {
                jj += dec[o];
            }
            int key = Convert.ToInt32(jj);

            for (int o = j + 3; o < x.Length; o++)
            {
                bb += dec[o];
            }

            char[] c = sd.Decryption(key, bb.ToCharArray());

            x = "";
            for (int d = 0; d < c.Length; d++)
            {
                x += c[d];
            }


            String[] splitted = x.Split(' ');


            String rel = "";

            for (int z = 0; z < splitted.Length; z++)
            {

                if (splitted[z].Length == 2)
                {
                    char[] y = splitted[z].ToCharArray();
                    String yy = y[1] + "";
                    int aa = Convert.ToInt32(yy);
                    char h = getChar(aa);
                    rel += y[0] + "" + h;

                }
                else
                {

                    char[] y = splitted[z].ToCharArray();
                    String yy = y[1] + "" + y[2];
                    int aa = Convert.ToInt32(yy);
                    char h = getChar(aa);
                    rel += y[0] + "" + h;

                }


            }
            string outs = reSpace(rel).Trim();
            return outs;

        }

        //Function: reSpace
        //Identifies the spaces within the encrypted text and replace it.
        public String reSpace(String x)
        {
            char[] l = x.ToCharArray();
            for (int z = 0; z < l.Length; z++)
                if (l[z] == '|') l[z] = ' ';

            string outs = "";
            for (int z = 0; z < l.Length; z++)
			outs+= l[z];
            return outs;
        }


        //Function: getChar
        //Returns the corresponding character by its index.
        public char getChar(int x)
        {
            return Zs[x];

        }
    }
}
