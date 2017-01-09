using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    class Main_Encryption
    {

        // Initial set of characters
        char[] Zs = {'|','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O'
            ,'P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d','e',
            'f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',' ',',','.',
            '0','1','2','3','4','5','6','7','8','9','!','@','#','$','%','^','&','*','(',')','_','+','-','=','/'
            ,'`','~',':',';','"','\'','<','>','?','/'};

        //Possible upgrade for this algorithm lies within this set of characters.
        //Changing the initial set's arrangement by its corresponding key.



        //Function: Encryption
        //Encrypts a string using permutation and combination. outsputs a String(encrypted text).
        public String Encryption(String x)
        {

            if (x.Contains("|J|")) return "error";

            ArrayList twos = new ArrayList();

            char[] l = x.ToCharArray();
            for (int z = 0; z < l.Length; z++)
            {
                if (l[z] == ' ') l[z] = '|';
            }


            if ((l.Length) % 2 != 0)
            {
                char[] ll = new char[l.Length + 1];
                for (int z = 0; z < l.Length; z++)
                {
                    ll[z] = l[z];
                }
                ll[ll.Length - 1] = ' ';

                for (int z = 0; z < ll.Length; z += 2)
                {
                    twos.Add(ll[z] + "" + getIndex(ll[z + 1]));
                    
                }
            }
            else
            {
                for (int z = 0; z < l.Length; z += 2)
                {
                    twos.Add(l[z] + "" + getIndex(l[z + 1]));
                    
                }
            }

            
            string outs = "";
            for (int z = 0; z < twos.Count; z++)
            {
		outs+= twos[z];

                if (z < twos.Count - 1)
                {
				outs+= " ";
                }
            }
          Sub_Encryption se = new Sub_Encryption();
            char[] zz = se.Encryption(outs.ToCharArray());
		outs= "";
            for (int c = 0; c < zz.Length; c++)
            {
			outs+= zz[c];
            }

            String J256 = se.key + "|J|" +outs;
            return J256.Trim();
        }

        //Function: getIndex
        //Identifies and returns the corresponding index of a character.
        public int getIndex(char x)
        {
            int index = 0;
            for (int z = 0; z < Zs.Length; z++)
            {
                if (x == Zs[z])
                {
                    index = z;
                    break;
                }
            }
            return index;

        }
    }
}
