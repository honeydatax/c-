using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharp_Shell
{
static class Constants
{
    public const int mz =0;
    public const int lastbb =2;
public const int nblock =4;
public const int reloc =6;
public const int parag512=8;
public const int add512 =10;
public const int AddMaxPar =12;
public const int ss =14;
public const int sp =16;
public const int WordChk =18;
public const int ip =20;
public const int cs =22;
public const int tableoff =24;
public const int over =26;


}

static class org{
public static int getInts(byte c0,byte c1) {
return c0+256*(c1);


}

public static byte getLow(int i) {
int l;
int h=i/256;
l=i-(h*256);
return (byte) l;


}
public static byte getHigh(int i) {
int l;
int h=i/256;
l=i-(h*256);
return (byte) h;


}

}

    public static class Program 
    {
        public static void Main() 
        {
   
        byte[] buff=new byte[60000];
        byte[] head=new byte[64];
          BinaryWriter bw;
          BinaryReader br;
                            
        String a;
        String b;
		   Console.Write("enter a file exe to convert ");
           a = Console.ReadLine();
             Console.Write("enter a file com to output ");
          b = Console.ReadLine();
           Console.WriteLine(a);
           Console.WriteLine(b);
        FileInfo f= new FileInfo(a);
        long l =f.Length;
           
           
            try {
            br = new BinaryReader(new FileStream(a, FileMode.Open));
         } catch (IOException e) {
            Console.WriteLine(e.Message + "\n Cannot open file.");
            return;
         }
         
         try {
            br.Read(buff,0,(int)l);
           
            
      
         } catch (IOException e) {
            Console.WriteLine(e.Message + "\n Cannot read from file.");
            return;
         }
         br.Close();
           
           
          
      head[0]=(byte)0xB8;

head[1]=(byte)0x24;

head[2]=(byte)0x0;

head[3]=(byte)0x8C;

head[4]=(byte)0xCB;

head[5]=(byte)0xF8;

head[6]=(byte)0x1;

head[7]=(byte)0xC3;

head[8]=(byte)0x8E;

head[9]=(byte)0xDB;

head[10]=(byte)0x8E;

head[11]=(byte)0xC3;

head[12]=(byte)0xB8;

head[13]= (byte)org.getLow(org.getInts(buff[Constants.ss],buff[Constants.ss+1])+0x10);
 head[14]=(byte) org.getHigh(org.getInts(buff[Constants.ss],buff[Constants.ss+1])+0x10);

 head[15]=(byte)0x1;

 head[16]=(byte)0xD8;

 head[17]=(byte)0x8E;

 head[18]=(byte)0xD0;

 head[19]=(byte)0xB8;
head[20]= (byte)org.getLow(org.getInts(buff[Constants.sp],buff[Constants.sp+1])+0x0);
 head[21]=(byte) org.getHigh(org.getInts(buff[Constants.sp],buff[Constants.sp+1])+0x0);
 
 head[22]=(byte)0x89;

 head[23]=(byte)0xC4;

 head[24]=(byte)0xB8;

 head[25]=(byte)0x0;

 head[26]=(byte)0x0;

 head[27]=(byte)0x1;

 head[28]=(byte)0xC3;


 head[29]=(byte)0xB8;

head[30]= (byte)org.getLow(org.getInts(buff[Constants.cs],buff[Constants.cs+1])+0x10);
 head[31]= (byte)org.getHigh(org.getInts(buff[Constants.cs],buff[Constants.cs+1])+0x10);


 head[32]=(byte)0x1;

 head[33]=(byte)0xD8;

 head[34]=(byte)0xBB;

 head[35]=(byte)0x80;

 head[36]=(byte)0x0;

 head[37]=(byte)0x2E;

 head[38]=(byte)0x89;

 head[39]=(byte)0x7;

 head[40]=(byte)0x4B;

 head[41]=(byte)0x4B;

 head[42]=(byte)0xB8;
head[43]= (byte)org.getLow(org.getInts(buff[Constants.ip],buff[Constants.ip+1])+0x0);
 head[44]=(byte) org.getHigh(org.getInts(buff[Constants.ip],buff[Constants.ip+1])+0x0);
 
 head[45]=(byte)0x2E;

 head[46]=(byte)0x89;

 head[47]=(byte)0x7;

 head[48]=(byte)0xB8;
head[49]= (byte)org.getLow(org.getInts(buff[Constants.AddMaxPar],buff[Constants.AddMaxPar+1])+0x0);
 head[50]= (byte)org.getHigh(org.getInts(buff[Constants.AddMaxPar],buff[Constants.AddMaxPar+1])+0x0);
 
head[51]=(byte)0x2E;

head[52]=(byte)0xFF;

head[53]=(byte)0x2F;







           
           
           
                    //create the file
         try {
            bw = new BinaryWriter(new FileStream(b, FileMode.Create));
            
         } catch (IOException e) {
            Console.WriteLine(e.Message + "\n Cannot create file.");
            return;
         }
         
                  //writing into the file
         try {
            bw.Write(head,0,64);
                       bw.Write(buff,0,(int)l);
         } catch (IOException e) {
            Console.WriteLine(e.Message + "\n Cannot write to file.");
            return;
         }
         bw.Close();
         


         
        }
        

    }
}
