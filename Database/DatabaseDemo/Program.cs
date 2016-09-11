using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Try to connect to danielbui database
            //using (SqlConnection conn = new SqlConnection())
            //{
            //    conn.ConnectionString = @"Server=CORSAIR;Database=danielbui;Trusted_Connection=true";

            //    conn.Open();

            //    if (conn.State != System.Data.ConnectionState.Open)
            //    {
            //        Console.WriteLine("What the heck?");
            //    }

            //    conn.Close();
            //}

            // So, looks like we can connect just fine. Let's see if we can get anything from the database.
            using (gaEntities db = new gaEntities())
            {
                IEnumerable<RawNoRegime> todoItems = db.RawNoRegimes;
                IEnumerable<View_RawNoRegime_Good> goodItems = db.View_RawNoRegime_Good;
                IEnumerable<View_RawNoRegime_Bad> badItems = db.View_RawNoRegime_Bad;

                Console.WriteLine("There are {0} items", todoItems.Count());
                Console.WriteLine("There are {0} good items", goodItems.Count());
                Console.WriteLine("There are {0} bad items", badItems.Count());

                var list = new List<Item>
                {
                    // Another way to get the average is: goodItems.Select(u => u.µ_Airspeed_hold_on).Average(). Pick your poison!

                    //new Item("µ_Airspeed_hold_on", goodItems.Average(item => item.µ_Airspeed_hold_on), badItems.Average(item => item.µ_Airspeed_hold_on)),
                    //new Item("OneCnt_Airspeed_hold_on", goodItems.Average(item => item.OneCnt_Airspeed_hold_on), badItems.Average(item => item.OneCnt_Airspeed_hold_on)),
                    //new Item("min_Alt_MSL__ft_", goodItems.Average(item => item.min_Alt_MSL__ft_), badItems.Average(item => item.min_Alt_MSL__ft_)),
                    //new Item("max_Alt_MSL__ft_", goodItems.Average(item => item.max_Alt_MSL__ft_), badItems.Average(item => item.max_Alt_MSL__ft_)),
                    //new Item("µ_Alt_MSL__ft_", goodItems.Average(item => item.µ_Alt_MSL__ft_), badItems.Average(item => item.µ_Alt_MSL__ft_)),
                    //new Item("s_Alt_MSL__ft_", goodItems.Average(item => item.s_Alt_MSL__ft_), badItems.Average(item => item.s_Alt_MSL__ft_)),
                    //new Item("µ_Altitude_hold_on", goodItems.Average(item => item.µ_Altitude_hold_on), badItems.Average(item => item.µ_Altitude_hold_on)),
                    //new Item("OneCnt_Altitude_hold_on", goodItems.Average(item => item.OneCnt_Altitude_hold_on), badItems.Average(item => item.OneCnt_Altitude_hold_on)),
                    //new Item("µ_Azimuth_hold_on", goodItems.Average(item => item.µ_Azimuth_hold_on), badItems.Average(item => item.µ_Azimuth_hold_on)),
                    //new Item("OneCnt_Azimuth_hold_on", goodItems.Average(item => item.OneCnt_Azimuth_hold_on), badItems.Average(item => item.OneCnt_Azimuth_hold_on)),

                    //new Item("min_Bat_2_Volt__V_", goodItems.Average(item => item.min_Bat_2_Volt__V_), badItems.Average(item => item.min_Bat_2_Volt__V_)),
                    //new Item("max_Bat_2_Volt__V_", goodItems.Average(item => item.max_Bat_2_Volt__V_), badItems.Average(item => item.max_Bat_2_Volt__V_)),
                    //new Item("µ_Bat_2_Volt__V_", goodItems.Average(item => item.µ_Bat_2_Volt__V_), badItems.Average(item => item.µ_Bat_2_Volt__V_)),
                    //new Item("s_Bat_2_Volt__V_", goodItems.Average(item => item.s_Bat_2_Volt__V_), badItems.Average(item => item.s_Bat_2_Volt__V_)),
                    //new Item("µ_Battery_leaking_current", goodItems.Average(item => item.µ_Battery_leaking_current_), badItems.Average(item => item.µ_Battery_leaking_current_)),
                    //new Item("OneCnt_Battery_leaking_current", goodItems.Average(item => item.OneCnt_Battery_leaking_current), badItems.Average(item => item.OneCnt_Battery_leaking_current)),
                    //new Item("min_Bus_1_Bat_Gnd_Amp__A_", goodItems.Average(item => item.min_Bus_1_Bat_Gnd_Amp__A_), badItems.Average(item => item.min_Bus_1_Bat_Gnd_Amp__A_)),
                    //new Item("max_Bus_1_Bat_Gnd_Amp__A_", goodItems.Average(item => item.max_Bus_1_Bat_Gnd_Amp__A_), badItems.Average(item => item.max_Bus_1_Bat_Gnd_Amp__A_)),
                    //new Item("µ_Bus_1_Bat_Gnd_Amp__A_", goodItems.Average(item => item.µ_Bus_1_Bat_Gnd_Amp__A_), badItems.Average(item => item.µ_Bus_1_Bat_Gnd_Amp__A_)),
                    //new Item("s_Bus_1_Bat_Gnd_Amp__A_", goodItems.Average(item => item.s_Bus_1_Bat_Gnd_Amp__A_), badItems.Average(item => item.s_Bus_1_Bat_Gnd_Amp__A_)),

                    //new Item("min_Bus_1_Current__A_", goodItems.Average(item => item.min_Bus_1_Current__A_), badItems.Average(item => item.min_Bus_1_Current__A_)),
                    //new Item("max_Bus_1_Current__A_", goodItems.Average(item => item.max_Bus_1_Current__A_), badItems.Average(item => item.max_Bus_1_Current__A_)),
                    //new Item("µ_Bus_1_Current__A_", goodItems.Average(item => item.µ_Bus_1_Current__A_), badItems.Average(item => item.µ_Bus_1_Current__A_)),
                    //new Item("s_Bus_1_Current__A_", goodItems.Average(item => item.s_Bus_1_Current__A_), badItems.Average(item => item.s_Bus_1_Current__A_)),
                    //new Item("min_Bus_1_Volt__V_", goodItems.Average(item => item.min_Bus_1_Volt__V_), badItems.Average(item => item.min_Bus_1_Volt__V_)),
                    //new Item("max_Bus_1_Volt__V_", goodItems.Average(item => item.max_Bus_1_Volt__V_), badItems.Average(item => item.max_Bus_1_Volt__V_)),
                    //new Item("µ_Bus_1_Volt__V_", goodItems.Average(item => item.µ_Bus_1_Volt__V_), badItems.Average(item => item.µ_Bus_1_Volt__V_)),
                    //new Item("s_Bus_1_Volt__V_", goodItems.Average(item => item.s_Bus_1_Volt__V_), badItems.Average(item => item.s_Bus_1_Volt__V_)),
                    //new Item("min_Bus_2_Bat_Gnd_Amp__A_", goodItems.Average(item => item.min_Bus_2_Bat_Gnd_Amp__A_), badItems.Average(item => item.min_Bus_2_Bat_Gnd_Amp__A_)),
                    //new Item("max_Bus_2_Bat_Gnd_Amp__A_", goodItems.Average(item => item.max_Bus_2_Bat_Gnd_Amp__A_), badItems.Average(item => item.max_Bus_2_Bat_Gnd_Amp__A_)),

                    //new Item("µ_Bus_2_Bat_Gnd_Amp__A_", goodItems.Average(item => item.µ_Bus_2_Bat_Gnd_Amp__A_), badItems.Average(item => item.µ_Bus_2_Bat_Gnd_Amp__A_)),
                    //new Item("s_Bus_2_Bat_Gnd_Amp__A_", goodItems.Average(item => item.s_Bus_2_Bat_Gnd_Amp__A_), badItems.Average(item => item.s_Bus_2_Bat_Gnd_Amp__A_)),
                    //new Item("min_Bus_2_Current__A_", goodItems.Average(item => item.min_Bus_2_Current__A_), badItems.Average(item => item.min_Bus_2_Current__A_)),
                    //new Item("max_Bus_2_Current__A_", goodItems.Average(item => item.max_Bus_2_Current__A_), badItems.Average(item => item.max_Bus_2_Current__A_)),
                    //new Item("µ_Bus_2_Current__A_", goodItems.Average(item => item.µ_Bus_2_Current__A_), badItems.Average(item => item.µ_Bus_2_Current__A_)),
                    //new Item("s_Bus_2_Current__A_", goodItems.Average(item => item.s_Bus_2_Current__A_), badItems.Average(item => item.s_Bus_2_Current__A_)),
                    //new Item("min_Bus_2_Volt__V_", goodItems.Average(item => item.min_Bus_2_Volt__V_), badItems.Average(item => item.min_Bus_2_Volt__V_)),
                    //new Item("max_Bus_2_Volt__V_", goodItems.Average(item => item.max_Bus_2_Volt__V_), badItems.Average(item => item.max_Bus_2_Volt__V_)),
                    //new Item("µ_Bus_2_Volt__V_", goodItems.Average(item => item.µ_Bus_2_Volt__V_), badItems.Average(item => item.µ_Bus_2_Volt__V_)),
                    //new Item("s_Bus_2_Volt__V_", goodItems.Average(item => item.s_Bus_2_Volt__V_), badItems.Average(item => item.s_Bus_2_Volt__V_)),

                    new Item("min_Compass_Hdg__DEG_", goodItems.Average(item => item.min_Compass_Hdg__DEG_), badItems.Average(item => item.min_Compass_Hdg__DEG_)),
                    new Item("max_Compass_Hdg__DEG_", goodItems.Average(item => item.max_Compass_Hdg__DEG_), badItems.Average(item => item.max_Compass_Hdg__DEG_)),
                    new Item("µ_Compass_Hdg__DEG_", goodItems.Average(item => item.µ_Compass_Hdg__DEG_), badItems.Average(item => item.µ_Compass_Hdg__DEG_)),
                    new Item("s_Compass_Hdg__DEG_", goodItems.Average(item => item.s_Compass_Hdg__DEG_), badItems.Average(item => item.s_Compass_Hdg__DEG_)),
                    new Item("min_DEEC_EGT__DEG_", goodItems.Average(item => item.min_DEEC_EGT__DEG_), badItems.Average(item => item.min_DEEC_EGT__DEG_)),
                    new Item("max_DEEC_EGT__DEG_", goodItems.Average(item => item.max_DEEC_EGT__DEG_), badItems.Average(item => item.max_DEEC_EGT__DEG_)),
                    new Item("µ_DEEC_EGT__DEG_", goodItems.Average(item => item.µ_DEEC_EGT__DEG_), badItems.Average(item => item.µ_DEEC_EGT__DEG_)),
                    new Item("s_DEEC_EGT__DEG_", goodItems.Average(item => item.s_DEEC_EGT__DEG_), badItems.Average(item => item.s_DEEC_EGT__DEG_)),
                    new Item("min_DEEC_Torque", goodItems.Average(item => item.min_DEEC_Torque), badItems.Average(item => item.min_DEEC_Torque)),
                    new Item("max_DEEC_Torque", goodItems.Average(item => item.max_DEEC_Torque), badItems.Average(item => item.max_DEEC_Torque)),

                    new Item("µ_DEEC_Torque", goodItems.Average(item => item.µ_DEEC_Torque), badItems.Average(item => item.µ_DEEC_Torque)),
                    new Item("s_DEEC_Torque", goodItems.Average(item => item.s_DEEC_Torque), badItems.Average(item => item.s_DEEC_Torque)),
                    new Item("min_Detent_Cmd", goodItems.Average(item => item.min_Detent_Cmd), badItems.Average(item => item.min_Detent_Cmd)),
                    new Item("max_Detent_Cmd", goodItems.Average(item => item.max_Detent_Cmd), badItems.Average(item => item.max_Detent_Cmd)),
                    new Item("µ_Detent_Cmd", goodItems.Average(item => item.µ_Detent_Cmd), badItems.Average(item => item.µ_Detent_Cmd)),
                    new Item("s_Detent_Cmd", goodItems.Average(item => item.s_Detent_Cmd), badItems.Average(item => item.s_Detent_Cmd)),
                    new Item("min_Dn_Sawtooth", goodItems.Average(item => item.min_Dn_Sawtooth), badItems.Average(item => item.min_Dn_Sawtooth)),
                    new Item("max_Dn_Sawtooth", goodItems.Average(item => item.max_Dn_Sawtooth), badItems.Average(item => item.max_Dn_Sawtooth)),
                    new Item("µ_Dn_Sawtooth", goodItems.Average(item => item.µ_Dn_Sawtooth), badItems.Average(item => item.µ_Dn_Sawtooth)),
                    new Item("s_Dn_Sawtooth", goodItems.Average(item => item.s_Dn_Sawtooth), badItems.Average(item => item.s_Dn_Sawtooth)),


                };

                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("          Channel          |     Good Flights     |     Bad Flights     |         Diff         |      Absolute      ");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

                int line = 0;
                foreach (var item in list)
                {
                    Console.WriteLine("{0, -27} {1, 22} {2, 21} {3, 22}", item.Name, item.Good, item.Bad, item.Diff);
                    line++;
                    if (line == 10)
                    {
                        Console.WriteLine();
                        line = 0;
                    }
                }

                Console.ReadLine();
            }
        }
    }

    public class Item
    {
        public string Name { get; private set; }
        public double? Good { get; private set; }
        public double? Bad { get; private set; }

        public double? Diff { get; private set; }

        public Item(string name, double? good, double? bad)
        {
            // TODO: Check for NULL
            Name = name;
            Good = good;
            Bad = bad;
            Diff = (Good - Bad) / Bad;
        }
    }
}
