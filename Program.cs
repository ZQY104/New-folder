using System;

namespace New_folder
{
    class Program
    {
        static void Main(string[] args)
        {
            double Valve_Port;
			string Valve_Stem;
            string Valve_Size;
            string Valve_Class;
			double P1;//upstream pressure;
			double P2;//downstream pressure;
			string Flow_Direction;//Flow up or flow down;
			string Trim;//balanced or unbalanced trim;
            string Shutoff;//Shutoff class II, III, IV, V, VI...
            string Packing;//SinglePTFE or EnviroSealPTFE or...
            string Bellows_Seal; //yes or no
			
			double Ftotal=0; //Ftotal=Fa+Fb+Fc+Fd; N
			double Fa=0; //force to overcome static unbalance of the valve plug; N
			double Fb=0; //force to provid seat load; N
			double Fc=0; //force to overcome packing friction; N
			double Fd=0; //additional force; N
			
			double Aunb=0;//unbalance area of trim;
			double Astem=0;//stem area; 
			double Aport=0;//port area; 
            double Pc=0;//port circumference;

            double Bellows_Effect_Area=0;
			

            /* Calculate Fa */
            Console.WriteLine("Bellows seal? yes or no ");
            Bellows_Seal = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Bellows Seal: {0}", Bellows_Seal);


			Console.WriteLine("please input stem size: unit 12.7mm or 1/2"); //input stem size
			Valve_Stem = Convert.ToString(Console.ReadLine());


            if(Bellows_Seal=="yes")
            {
                Console.WriteLine("please input valve size: 0.5 / 1 / 1.5/ 2"); //input valve size
			    Valve_Size = Convert.ToString(Console.ReadLine());
                switch(Valve_Size)
                {
                    case "0.5": case"1/2":
                    case "0.75": case"3/4":
                    case "1":
                    case "1.25": case"1 1/4":
                    case "1.5": case"1 1/2":
                    case "2":
                    Bellows_Effect_Area = 0.353;//unit square inch;
                    break;
                    default:
                    Bellows_Effect_Area = 1.340;//unit square inch;
                    break;
                }
                Astem = Bellows_Effect_Area;//if bellows seal is in use, use bellows effect area instead of stem area in Fa calculation;
            }
            else
            {//ref catalog 14 table 3
                switch (Valve_Stem) 
			    {
			    	case "7.9mm": case "5/16": Astem = 0.08;break;
			    	case "9.5mm": case "3/8":  Astem =0.11;break;
			    	case "12.7mm":case "1/2":  Astem =.2;break;
			    	case "19mm":  case "3/4":  Astem = .44;break;
			    	case "25.4mm":case "1":    Astem = .79;break;
			    	case "32mm":  case "1 1/4":Astem =1.23;break;
			    	case "38mm":  case "1 1/2":Astem =1.77;break;
			    	case "51mm":  case "2":    Astem = 3.14;break;	
                    case "70mm":  case "3 2/4":Astem = 5.94;break;		
			    }
            }
            Console.WriteLine("Astem / Bellow Effect Area = {0}",Astem);

			
			Console.WriteLine("please input port size: unit inch"); //input port size
			Valve_Port = Convert.ToDouble(Console.ReadLine());//catalog 14, table 2 , unit inch
			switch (Valve_Port) 
			{
				case 0.1875:Aport = 0.028; Pc = 0.59; Aunb = 0;break;
				case 0.25  :Aport = 0.049; Pc = 0.78; Aunb = 0;break;
				case 0.375: Aport = 0.110; Pc = 1.18; Aunb = 0;break;
				case 0.5:   Aport = 0.196; Pc = 1.57; Aunb = 0;break;
				case 0.625: Aport = 0.307; Pc = 1.96; Aunb = 0;break;
				
				case 0.75:  Aport = 0.441; Pc = 2.36; 
                Aunb = 0;	break;
				case 0.875: Aport = 0.601; Pc = 2.75; 
                Aunb = 0;	break;
				case 1:     Aport = 0.785; Pc = 3.14; Aunb = 0;	break;
				case 1.125: Aport = 0.994; Pc = 3.53; Aunb = 0;	break;
				case 1.25:  Aport = 1.23;  Pc = 3.93; Aunb = 0;	break;

                case 1.3125:Aport = 1.35;  Pc = 4.12; Aunb = 0;	break;
                case 1.875: Aport = 2.76;  Pc = 5.89; Aunb = 0;	break;

				case 2:     Aport = 3.14;  Pc = 6.28; Aunb = 0;	break;
                case 2.3125:Aport = 4.20;  Pc = 7.26; Aunb = 0;	break;
                case 2.875: Aport = 6.49;  Pc = 9.03; Aunb = 0;	break;
				case 3:     Aport = 7.07;  Pc = 9.42; Aunb = 0;	break;
                case 3.4375:Aport = 9.28;  Pc = 10.80;Aunb = 0; break;
				case 4:     Aport = 12.57; Pc = 12.57;Aunb = 0; break;
                case 4.375: Aport = 15.03; Pc = 13.74;Aunb = 0; break;
				case 5:     Aport = 19.64; Pc = 15.7; Aunb = 0;	break;
                case 5.375: Aport = 22.69; Pc = 16.89;Aunb = 0; break;
                    
                case 6:     Aport = 0.601; Pc = 18.85;Aunb = 0; break;
				case 7:     Aport = 0.785; Pc = 22.0; Aunb = 0;	break;
				case 8:     Aport = 50.24; Pc = 25.13;Aunb = 0; break;
				case 10:    Aport = 78.5;  Pc = 31.42;Aunb = 0; break;
				// ref catalog 14 table 2, to be continue...				
			}
            Console.WriteLine("Aport ={0}, Aunb = {1}", Aport,Aunb);

			
			
		    Console.WriteLine("please input P1"); //input flow diection;
			P1 = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("please input P2"); //input flow diection;
			P2 = Convert.ToDouble(Console.ReadLine());

			
			Console.WriteLine("please input Flow direction: flow up / flow down"); //input flow diection;
			Flow_Direction = Convert.ToString(Console.ReadLine());
			Console.WriteLine("{0}",Flow_Direction);
			
			Console.WriteLine("please input Trim style: balanced / unbalanced"); //input trim style;
			Trim = Convert.ToString(Console.ReadLine());
			Console.WriteLine("{0}",Trim);
			
			if (Flow_Direction =="flow up" && Trim=="balanced")          {Fa = -((P1-P2) * Aunb - P1 * Astem);}
			else if (Flow_Direction =="flow up" && Trim=="unbalanced")   {Fa = (P1-P2) * Aport +P2 * Astem;}
			else if (Flow_Direction =="flow down" && Trim=="balanced")   {Fa = (P1-P2) * Aunb+P2 * Astem;}
			else if (Flow_Direction =="flow down" && Trim=="unbalanced") {Fa = -((P1-P2) * Aport-P1 * Astem);}
			else {Console.WriteLine("please check if you have wrong input of flow direction or trim style");}
			Console.WriteLine("Fa = {0}",Fa);   //calculate Fa;
            if(Fa==0) {Console.WriteLine("Fa = 0???? There must be something wrong.");}


            /* Calculat Fb */
			Console.WriteLine("please input shutoff class: II, III, IV, V, VI?"); //input Shutoff class;
			Shutoff = Convert.ToString(Console.ReadLine());
			Console.WriteLine("{0}",Shutoff);
            if(Shutoff =="II")                           {Fb=20*Pc;}
            else if (Shutoff =="III")                    {Fb = 40*Pc;}
            else if (Shutoff =="IV" && Valve_Port<=4.375){Fb = 40*Pc;}
            else if (Shutoff =="IV"&& Valve_Port>4.375)  {Fb=80*Pc;}
            else if (Shutoff =="V")                      {Fb = (100+0.122*(P1-P2))*Pc;}
            else if (Shutoff =="VI")                     {Fb = 300*Pc;}
            else {Console.WriteLine("something wrong with shutoff class");}
            Console.WriteLine("Fb = {0}", Fb);

            Console.WriteLine("please input packing seal type;  SinglePTFE \n DoublePTFE \n EnviroSeal_PTFE \n EnviroSeal_GraphiteULF \n EnviroSeal_Duplex \n HighSeal_Graphite \n HighSeal_GraphiteULF \n");
            Packing = Convert.ToString(Console.ReadLine());

            double Fc_EnviroSeal_PTFE=0;
			double Fc_EnviroSeal_Duplex=0;
            double Fc_EnviroSeal_GraphiteULF=0;
			double Fc_HighSeal_GraphiteULF=0;
			double Fc_HighSeal_Graphite=0;
			double Fc_ISOSeal_PTFE=0;
            double Fc_ISOSeal_Graphite=0;
            double Fc_SinglePTFE=0;
            double Fc_DoublePTFE=0;
            double Fc_PTFE_Composition=0;
            double Fc_Graphite=0;
            double Fc_RibbonFilament=0;

            switch (Valve_Stem) //ref catalog 14 table 3
			{
			    case "7.9mm": case "5/16": Fc_SinglePTFE = 20; Fc_DoublePTFE =30;   Fc_EnviroSeal_PTFE = 60;Fc_EnviroSeal_Duplex= 60;  Fc_EnviroSeal_GraphiteULF=0;     Fc_HighSeal_GraphiteULF=0;Fc_HighSeal_Graphite=0; break; //UNIT: POUNDS
			    case "9.5mm": case "3/8":  Fc_SinglePTFE = 38; Fc_DoublePTFE =56;   Fc_EnviroSeal_PTFE = 125;Fc_EnviroSeal_Duplex= 125;Fc_EnviroSeal_GraphiteULF=210; Fc_HighSeal_GraphiteULF=210;Fc_HighSeal_Graphite=420;break;
 		        case "12.7mm":case "1/2":  Fc_SinglePTFE = 50; Fc_DoublePTFE =75;   Fc_EnviroSeal_PTFE = 170;Fc_EnviroSeal_Duplex= 170;Fc_EnviroSeal_GraphiteULF=280; Fc_HighSeal_GraphiteULF=280;Fc_HighSeal_Graphite=1130;break;
			    case "15.9mm":case "5/8":  Fc_SinglePTFE = 63; Fc_DoublePTFE =95;   Fc_EnviroSeal_PTFE = 210;Fc_EnviroSeal_Duplex= 210;Fc_EnviroSeal_GraphiteULF=380; Fc_HighSeal_GraphiteULF=380;Fc_HighSeal_Graphite=1625;break;
                case "19mm":  case "3/4":  Fc_SinglePTFE = 75; Fc_DoublePTFE =112.5;Fc_EnviroSeal_PTFE = 250;Fc_EnviroSeal_Duplex= 250;Fc_EnviroSeal_GraphiteULF=530; Fc_HighSeal_GraphiteULF=530;Fc_HighSeal_Graphite=2120;break;
			    case "25.4mm":case "1":    Fc_SinglePTFE = 100;Fc_DoublePTFE =150;  Fc_EnviroSeal_PTFE = 340;Fc_EnviroSeal_Duplex= 340;Fc_EnviroSeal_GraphiteULF=840; Fc_HighSeal_GraphiteULF=840;Fc_HighSeal_Graphite=3390;break;
			    case "32mm":  case "1 1/4":Fc_SinglePTFE = 120;Fc_DoublePTFE =180;  Fc_EnviroSeal_PTFE = 425;Fc_EnviroSeal_Duplex= 425;Fc_EnviroSeal_GraphiteULF=1100;Fc_HighSeal_GraphiteULF=1100;Fc_HighSeal_Graphite=4240; break;
			    case "38mm":  case "1 1/2":Fc_SinglePTFE = 150;Fc_DoublePTFE =225;  Fc_EnviroSeal_PTFE = 510;Fc_EnviroSeal_Duplex= 510;Fc_EnviroSeal_GraphiteULF=1183;Fc_HighSeal_GraphiteULF=1183;Fc_HighSeal_Graphite=5090; break;//Not in catalog 14, calculate by interpolation;
			    case "51mm":  case "2":    Fc_SinglePTFE = 200;Fc_DoublePTFE =300;  Fc_EnviroSeal_PTFE = 725;Fc_EnviroSeal_Duplex= 725;Fc_EnviroSeal_GraphiteULF=1350;Fc_HighSeal_GraphiteULF=1350;Fc_HighSeal_Graphite=6790; break;	
                case "70mm":  case "2 3/4":Fc_SinglePTFE = 275;Fc_DoublePTFE =412.5;Fc_EnviroSeal_PTFE = 997;Fc_EnviroSeal_Duplex= 997;Fc_EnviroSeal_GraphiteULF=1600;Fc_HighSeal_GraphiteULF=1600;Fc_HighSeal_Graphite=9340; break;//Not in catalog 14, calculate by interpolation;			
		    }
            
            switch(Packing)
            {
                case "SinglePTFE":             Fc=Fc_SinglePTFE;            break;
                case "DoublePTFE":             Fc=Fc_DoublePTFE;            break;
                case "EnviroSeal_PTFE":        Fc=Fc_EnviroSeal_PTFE;       break;
                case "EnviroSeal_GraphiteULF": Fc=Fc_EnviroSeal_GraphiteULF;break;
                case "EnviroSeal_Duplex":      Fc=Fc_EnviroSeal_Duplex;     break;
                case "HighSeal_GraphiteULF":   Fc=Fc_HighSeal_GraphiteULF;  break;
                case "HighSeal_Graphite":      Fc=Fc_HighSeal_Graphite;     break;
            }
            Console.WriteLine("Fc = {0} Pounds",Fc);
            Ftotal = Fa+Fb+Fc+Fd;		
            Console.WriteLine("Ftotal = {0} Pounds",Ftotal);	
         
        }
    }
}
