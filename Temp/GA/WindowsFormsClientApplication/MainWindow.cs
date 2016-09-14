using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using FlightDataModel;
using SharedLibrary;
using System.Reflection;
using System.Linq.Dynamic;

namespace WindowsFormsClientApplication
{
    public partial class MainWindow : Form
    {
        private List<Item> _dataList;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void getDataButton_Click(object sender, EventArgs e)
        {
            using (FlightDataEntities db = new FlightDataEntities())
            {
                //var todoItems = db.RawNoRegimes;
                var goodItems = db.View_RawNoRegime_Good.ToList();
                IEnumerable<View_RawNoRegime_Bad> badItems = db.View_RawNoRegime_Bad;

                Debug.WriteLine("There are {0} good items", goodItems.Count());
                Debug.WriteLine("There are {0} bad items", badItems.Count());

                foreach (PropertyInfo pi in goodItems[0].GetType().GetProperties())
                {
                    try
                    {
                        Debug.WriteLine(pi.Name);

                        // TODO: Use some kind of dynamic LINQ (or Expression Tree) to calculate the average
                        // for the columns.
                        var average = goodItems.Average(item => item.µ_Airspeed_hold_on);

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
                //return;

                _dataList = new List<Item>
                {
                    new Item("µ_Airspeed_hold_on", goodItems.Average(item => item.µ_Airspeed_hold_on), badItems.Average(item => item.µ_Airspeed_hold_on)),
                    //new Item("OneCnt_Airspeed_hold_on", goodItems.Average(item => item.OneCnt_Airspeed_hold_on), badItems.Average(item => item.OneCnt_Airspeed_hold_on)),
                    new Item("min_Alt_MSL__ft_", goodItems.Average(item => item.min_Alt_MSL__ft_), badItems.Average(item => item.min_Alt_MSL__ft_)),
                    new Item("max_Alt_MSL__ft_", goodItems.Average(item => item.max_Alt_MSL__ft_), badItems.Average(item => item.max_Alt_MSL__ft_)),
                    new Item("µ_Alt_MSL__ft_", goodItems.Average(item => item.µ_Alt_MSL__ft_), badItems.Average(item => item.µ_Alt_MSL__ft_)),
                    new Item("s_Alt_MSL__ft_", goodItems.Average(item => item.s_Alt_MSL__ft_), badItems.Average(item => item.s_Alt_MSL__ft_)),
                    new Item("µ_Altitude_hold_on", goodItems.Average(item => item.µ_Altitude_hold_on), badItems.Average(item => item.µ_Altitude_hold_on)),
                    //new Item("OneCnt_Altitude_hold_on", goodItems.Average(item => item.OneCnt_Altitude_hold_on), badItems.Average(item => item.OneCnt_Altitude_hold_on)),
                    new Item("µ_Azimuth_hold_on", goodItems.Average(item => item.µ_Azimuth_hold_on), badItems.Average(item => item.µ_Azimuth_hold_on)),
                    //new Item("OneCnt_Azimuth_hold_on", goodItems.Average(item => item.OneCnt_Azimuth_hold_on), badItems.Average(item => item.OneCnt_Azimuth_hold_on)),

                    new Item("min_Bat_2_Volt__V_", goodItems.Average(item => item.min_Bat_2_Volt__V_), badItems.Average(item => item.min_Bat_2_Volt__V_)),
                    new Item("max_Bat_2_Volt__V_", goodItems.Average(item => item.max_Bat_2_Volt__V_), badItems.Average(item => item.max_Bat_2_Volt__V_)),
                    new Item("µ_Bat_2_Volt__V_", goodItems.Average(item => item.µ_Bat_2_Volt__V_), badItems.Average(item => item.µ_Bat_2_Volt__V_)),
                    new Item("s_Bat_2_Volt__V_", goodItems.Average(item => item.s_Bat_2_Volt__V_), badItems.Average(item => item.s_Bat_2_Volt__V_)),
                    new Item("µ_Battery_leaking_current", goodItems.Average(item => item.µ_Battery_leaking_current_), badItems.Average(item => item.µ_Battery_leaking_current_)),
                    //new Item("OneCnt_Battery_leaking_current", goodItems.Average(item => item.OneCnt_Battery_leaking_current), badItems.Average(item => item.OneCnt_Battery_leaking_current)),
                    new Item("min_Bus_1_Bat_Gnd_Amp__A_", goodItems.Average(item => item.min_Bus_1_Bat_Gnd_Amp__A_), badItems.Average(item => item.min_Bus_1_Bat_Gnd_Amp__A_)),
                    new Item("max_Bus_1_Bat_Gnd_Amp__A_", goodItems.Average(item => item.max_Bus_1_Bat_Gnd_Amp__A_), badItems.Average(item => item.max_Bus_1_Bat_Gnd_Amp__A_)),
                    new Item("µ_Bus_1_Bat_Gnd_Amp__A_", goodItems.Average(item => item.µ_Bus_1_Bat_Gnd_Amp__A_), badItems.Average(item => item.µ_Bus_1_Bat_Gnd_Amp__A_)),
                    new Item("s_Bus_1_Bat_Gnd_Amp__A_", goodItems.Average(item => item.s_Bus_1_Bat_Gnd_Amp__A_), badItems.Average(item => item.s_Bus_1_Bat_Gnd_Amp__A_)),

                    new Item("min_Bus_1_Current__A_", goodItems.Average(item => item.min_Bus_1_Current__A_), badItems.Average(item => item.min_Bus_1_Current__A_)),
                    new Item("max_Bus_1_Current__A_", goodItems.Average(item => item.max_Bus_1_Current__A_), badItems.Average(item => item.max_Bus_1_Current__A_)),
                    new Item("µ_Bus_1_Current__A_", goodItems.Average(item => item.µ_Bus_1_Current__A_), badItems.Average(item => item.µ_Bus_1_Current__A_)),
                    new Item("s_Bus_1_Current__A_", goodItems.Average(item => item.s_Bus_1_Current__A_), badItems.Average(item => item.s_Bus_1_Current__A_)),
                    new Item("min_Bus_1_Volt__V_", goodItems.Average(item => item.min_Bus_1_Volt__V_), badItems.Average(item => item.min_Bus_1_Volt__V_)),
                    new Item("max_Bus_1_Volt__V_", goodItems.Average(item => item.max_Bus_1_Volt__V_), badItems.Average(item => item.max_Bus_1_Volt__V_)),
                    new Item("µ_Bus_1_Volt__V_", goodItems.Average(item => item.µ_Bus_1_Volt__V_), badItems.Average(item => item.µ_Bus_1_Volt__V_)),
                    new Item("s_Bus_1_Volt__V_", goodItems.Average(item => item.s_Bus_1_Volt__V_), badItems.Average(item => item.s_Bus_1_Volt__V_)),
                    new Item("min_Bus_2_Bat_Gnd_Amp__A_", goodItems.Average(item => item.min_Bus_2_Bat_Gnd_Amp__A_), badItems.Average(item => item.min_Bus_2_Bat_Gnd_Amp__A_)),
                    new Item("max_Bus_2_Bat_Gnd_Amp__A_", goodItems.Average(item => item.max_Bus_2_Bat_Gnd_Amp__A_), badItems.Average(item => item.max_Bus_2_Bat_Gnd_Amp__A_)),

                    new Item("µ_Bus_2_Bat_Gnd_Amp__A_", goodItems.Average(item => item.µ_Bus_2_Bat_Gnd_Amp__A_), badItems.Average(item => item.µ_Bus_2_Bat_Gnd_Amp__A_)),
                    new Item("s_Bus_2_Bat_Gnd_Amp__A_", goodItems.Average(item => item.s_Bus_2_Bat_Gnd_Amp__A_), badItems.Average(item => item.s_Bus_2_Bat_Gnd_Amp__A_)),
                    new Item("min_Bus_2_Current__A_", goodItems.Average(item => item.min_Bus_2_Current__A_), badItems.Average(item => item.min_Bus_2_Current__A_)),
                    new Item("max_Bus_2_Current__A_", goodItems.Average(item => item.max_Bus_2_Current__A_), badItems.Average(item => item.max_Bus_2_Current__A_)),
                    new Item("µ_Bus_2_Current__A_", goodItems.Average(item => item.µ_Bus_2_Current__A_), badItems.Average(item => item.µ_Bus_2_Current__A_)),
                    new Item("s_Bus_2_Current__A_", goodItems.Average(item => item.s_Bus_2_Current__A_), badItems.Average(item => item.s_Bus_2_Current__A_)),
                    new Item("min_Bus_2_Volt__V_", goodItems.Average(item => item.min_Bus_2_Volt__V_), badItems.Average(item => item.min_Bus_2_Volt__V_)),
                    new Item("max_Bus_2_Volt__V_", goodItems.Average(item => item.max_Bus_2_Volt__V_), badItems.Average(item => item.max_Bus_2_Volt__V_)),
                    new Item("µ_Bus_2_Volt__V_", goodItems.Average(item => item.µ_Bus_2_Volt__V_), badItems.Average(item => item.µ_Bus_2_Volt__V_)),
                    new Item("s_Bus_2_Volt__V_", goodItems.Average(item => item.s_Bus_2_Volt__V_), badItems.Average(item => item.s_Bus_2_Volt__V_)),

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

                    new Item("min_EFIU_EGT__DEG_", goodItems.Average(item => item.min_EFIU_EGT__DEG_), badItems.Average(item => item.min_EFIU_EGT__DEG_)),
                    new Item("max_EFIU_EGT__DEG_", goodItems.Average(item => item.max_EFIU_EGT__DEG_), badItems.Average(item => item.max_EFIU_EGT__DEG_)),
                    new Item("µ_EFIU_EGT__DEG_", goodItems.Average(item => item.µ_EFIU_EGT__DEG_), badItems.Average(item => item.µ_EFIU_EGT__DEG_)),
                    new Item("s_EFIU_EGT__DEG_", goodItems.Average(item => item.s_EFIU_EGT__DEG_), badItems.Average(item => item.s_EFIU_EGT__DEG_)),
                    new Item("min_EFIU_Torque", goodItems.Average(item => item.min_EFIU_Torque), badItems.Average(item => item.min_EFIU_Torque)),
                    new Item("max_EFIU_Torque", goodItems.Average(item => item.max_EFIU_Torque), badItems.Average(item => item.max_EFIU_Torque)),
                    new Item("µ_EFIU_Torque", goodItems.Average(item => item.µ_EFIU_Torque), badItems.Average(item => item.µ_EFIU_Torque)),
                    new Item("s_EFIU_Torque", goodItems.Average(item => item.s_EFIU_Torque), badItems.Average(item => item.s_EFIU_Torque)),
                    new Item("min_Eng_Speed_Cmd", goodItems.Average(item => item.min_Eng_Speed_Cmd), badItems.Average(item => item.min_Eng_Speed_Cmd)),
                    new Item("max_Eng_Speed_Cmd", goodItems.Average(item => item.max_Eng_Speed_Cmd), badItems.Average(item => item.max_Eng_Speed_Cmd)),

                    new Item("µ_Eng_Speed_Cmd", goodItems.Average(item => item.µ_Eng_Speed_Cmd), badItems.Average(item => item.µ_Eng_Speed_Cmd)),
                    new Item("s_Eng_Speed_Cmd", goodItems.Average(item => item.s_Eng_Speed_Cmd), badItems.Average(item => item.s_Eng_Speed_Cmd)),
                    new Item("min_Eng_Torque", goodItems.Average(item => item.min_Eng_Torque), badItems.Average(item => item.min_Eng_Torque)),
                    new Item("max_Eng_Torque", goodItems.Average(item => item.max_Eng_Torque), badItems.Average(item => item.max_Eng_Torque)),
                    new Item("µ_Eng_Torque", goodItems.Average(item => item.µ_Eng_Torque), badItems.Average(item => item.µ_Eng_Torque)),
                    new Item("s_Eng_Torque", goodItems.Average(item => item.s_Eng_Torque), badItems.Average(item => item.s_Eng_Torque)),
                    new Item("µ_GCU_inhibit", goodItems.Average(item => item.µ_GCU_inhibit), badItems.Average(item => item.µ_GCU_inhibit)),
                    //new Item("OneCnt_GCU_inhibit", goodItems.Average(item => item.OneCnt_GCU_inhibit), badItems.Average(item => item.OneCnt_GCU_inhibit)),
                    new Item("µ_GCU_reset", goodItems.Average(item => item.µ_GCU_reset), badItems.Average(item => item.µ_GCU_reset)),
                    //new Item("OneCnt_GCU_reset", goodItems.Average(item => item.OneCnt_GCU_reset), badItems.Average(item => item.OneCnt_GCU_reset)),

                    new Item("min_GCU_Temp__DEG_", goodItems.Average(item => item.min_GCU_Temp__DEG_), badItems.Average(item => item.min_GCU_Temp__DEG_)),
                    new Item("max_GCU_Temp__DEG_", goodItems.Average(item => item.max_GCU_Temp__DEG_), badItems.Average(item => item.max_GCU_Temp__DEG_)),
                    new Item("µ_GCU_Temp__DEG_", goodItems.Average(item => item.µ_GCU_Temp__DEG_), badItems.Average(item => item.µ_GCU_Temp__DEG_)),
                    new Item("s_GCU_Temp__DEG_", goodItems.Average(item => item.s_GCU_Temp__DEG_), badItems.Average(item => item.s_GCU_Temp__DEG_)),
                    new Item("min_Gen_Air_Temp__DEG_", goodItems.Average(item => item.min_Gen_Air_Temp__DEG_), badItems.Average(item => item.min_Gen_Air_Temp__DEG_)),
                    new Item("max_Gen_Air_Temp__DEG_", goodItems.Average(item => item.max_Gen_Air_Temp__DEG_), badItems.Average(item => item.max_Gen_Air_Temp__DEG_)),
                    new Item("µ_Gen_Air_Temp__DEG_", goodItems.Average(item => item.µ_Gen_Air_Temp__DEG_), badItems.Average(item => item.µ_Gen_Air_Temp__DEG_)),
                    new Item("s_Gen_Air_Temp__DEG_", goodItems.Average(item => item.s_Gen_Air_Temp__DEG_), badItems.Average(item => item.s_Gen_Air_Temp__DEG_)),
                    new Item("min_Generator_Amp__A_", goodItems.Average(item => item.min_Generator_Amp__A_), badItems.Average(item => item.min_Generator_Amp__A_)),
                    new Item("max_Generator_Amp__A_", goodItems.Average(item => item.max_Generator_Amp__A_), badItems.Average(item => item.max_Generator_Amp__A_)),

                    new Item("µ_Generator_Amp__A_", goodItems.Average(item => item.µ_Generator_Amp__A_), badItems.Average(item => item.µ_Generator_Amp__A_)),
                    new Item("s_Generator_Amp__A_", goodItems.Average(item => item.s_Generator_Amp__A_), badItems.Average(item => item.s_Generator_Amp__A_)),
                    new Item("min_GPS_Alt__ft_", goodItems.Average(item => item.min_GPS_Alt__ft_), badItems.Average(item => item.min_GPS_Alt__ft_)),
                    new Item("max_GPS_Alt__ft_", goodItems.Average(item => item.max_GPS_Alt__ft_), badItems.Average(item => item.max_GPS_Alt__ft_)),
                    new Item("µ_GPS_Alt__ft_", goodItems.Average(item => item.µ_GPS_Alt__ft_), badItems.Average(item => item.µ_GPS_Alt__ft_)),
                    new Item("s_GPS_Alt__ft_", goodItems.Average(item => item.s_GPS_Alt__ft_), badItems.Average(item => item.s_GPS_Alt__ft_)),
                    new Item("µ_In_flight_reset_detected_by_UAV", goodItems.Average(item => item.µ_In_flight_reset_detected_by_UAV), badItems.Average(item => item.µ_In_flight_reset_detected_by_UAV)),
                    //new Item("OneCnt_In_flight_reset_detected_by_UAV", goodItems.Average(item => item.OneCnt_In_flight_reset_detected_by_UAV), badItems.Average(item => item.OneCnt_In_flight_reset_detected_by_UAV)),
                    new Item("min_Norm_Accel__g_", goodItems.Average(item => item.min_Norm_Accel__g_), badItems.Average(item => item.min_Norm_Accel__g_)),
                    new Item("max_Norm_Accel__g_", goodItems.Average(item => item.max_Norm_Accel__g_), badItems.Average(item => item.max_Norm_Accel__g_)),

                    new Item("µ_Norm_Accel__g_", goodItems.Average(item => item.µ_Norm_Accel__g_), badItems.Average(item => item.µ_Norm_Accel__g_)),
                    new Item("s_Norm_Accel__g_", goodItems.Average(item => item.s_Norm_Accel__g_), badItems.Average(item => item.s_Norm_Accel__g_)),
                    new Item("min_OAT__DEG_", goodItems.Average(item => item.min_OAT__DEG_), badItems.Average(item => item.min_OAT__DEG_)),
                    new Item("max_OAT__DEG_", goodItems.Average(item => item.max_OAT__DEG_), badItems.Average(item => item.max_OAT__DEG_)),
                    new Item("µ_OAT__DEG_", goodItems.Average(item => item.µ_OAT__DEG_), badItems.Average(item => item.µ_OAT__DEG_)),
                    new Item("s_OAT__DEG_", goodItems.Average(item => item.s_OAT__DEG_), badItems.Average(item => item.s_OAT__DEG_)),
                    new Item("min_Pitch_Rate__DEG_", goodItems.Average(item => item.min_Pitch_Rate__DEG_), badItems.Average(item => item.min_Pitch_Rate__DEG_)),
                    new Item("max_Pitch_Rate__DEG_", goodItems.Average(item => item.max_Pitch_Rate__DEG_), badItems.Average(item => item.max_Pitch_Rate__DEG_)),
                    new Item("µ_Pitch_Rate__DEG_", goodItems.Average(item => item.µ_Pitch_Rate__DEG_), badItems.Average(item => item.µ_Pitch_Rate__DEG_)),
                    new Item("s_Pitch_Rate__DEG_", goodItems.Average(item => item.s_Pitch_Rate__DEG_), badItems.Average(item => item.s_Pitch_Rate__DEG_)),

                    new Item("min_PMA_Temp__DEG_", goodItems.Average(item => item.min_PMA_Temp__DEG_), badItems.Average(item => item.min_PMA_Temp__DEG_)),
                    new Item("max_PMA_Temp__DEG_", goodItems.Average(item => item.max_PMA_Temp__DEG_), badItems.Average(item => item.max_PMA_Temp__DEG_)),
                    new Item("µ_PMA_Temp__DEG_", goodItems.Average(item => item.µ_PMA_Temp__DEG_), badItems.Average(item => item.µ_PMA_Temp__DEG_)),
                    new Item("s_PMA_Temp__DEG_", goodItems.Average(item => item.s_PMA_Temp__DEG_), badItems.Average(item => item.s_PMA_Temp__DEG_)),
                    new Item("min_Power_Cmd", goodItems.Average(item => item.min_Power_Cmd), badItems.Average(item => item.min_Power_Cmd)),
                    new Item("max_Power_Cmd", goodItems.Average(item => item.max_Power_Cmd), badItems.Average(item => item.max_Power_Cmd)),
                    new Item("µ_Power_Cmd", goodItems.Average(item => item.µ_Power_Cmd), badItems.Average(item => item.µ_Power_Cmd)),
                    new Item("s_Power_Cmd", goodItems.Average(item => item.s_Power_Cmd), badItems.Average(item => item.s_Power_Cmd)),
                    new Item("min_Power_Gauge", goodItems.Average(item => item.min_Power_Gauge), badItems.Average(item => item.min_Power_Gauge)),
                    new Item("max_Power_Gauge", goodItems.Average(item => item.max_Power_Gauge), badItems.Average(item => item.max_Power_Gauge)),

                    new Item("µ_Power_Gauge", goodItems.Average(item => item.µ_Power_Gauge), badItems.Average(item => item.µ_Power_Gauge)),
                    new Item("s_Power_Gauge", goodItems.Average(item => item.s_Power_Gauge), badItems.Average(item => item.s_Power_Gauge)),
                    new Item("min_Power_Lvr_Cmd", goodItems.Average(item => item.min_Power_Lvr_Cmd), badItems.Average(item => item.min_Power_Lvr_Cmd)),
                    new Item("max_Power_Lvr_Cmd", goodItems.Average(item => item.max_Power_Lvr_Cmd), badItems.Average(item => item.max_Power_Lvr_Cmd)),
                    new Item("µ_Power_Lvr_Cmd", goodItems.Average(item => item.µ_Power_Lvr_Cmd), badItems.Average(item => item.µ_Power_Lvr_Cmd)),
                    new Item("s_Power_Lvr_Cmd", goodItems.Average(item => item.s_Power_Lvr_Cmd), badItems.Average(item => item.s_Power_Lvr_Cmd)),
                    new Item("µ_Preprogrammed_mode_on", goodItems.Average(item => item.µ_Preprogrammed_mode_on), badItems.Average(item => item.µ_Preprogrammed_mode_on)),
                    //new Item("OneCnt_Preprogrammed_mode_on", goodItems.Average(item => item.OneCnt_Preprogrammed_mode_on), badItems.Average(item => item.OneCnt_Preprogrammed_mode_on)),
                    new Item("min_Pri_AS__KIAS_", goodItems.Average(item => item.min_Pri_AS__KIAS_), badItems.Average(item => item.min_Pri_AS__KIAS_)),
                    new Item("max_Pri_AS__KIAS_", goodItems.Average(item => item.max_Pri_AS__KIAS_), badItems.Average(item => item.max_Pri_AS__KIAS_)),

                    new Item("µ_Pri_AS__KIAS_", goodItems.Average(item => item.µ_Pri_AS__KIAS_), badItems.Average(item => item.µ_Pri_AS__KIAS_)),
                    new Item("s_Pri_AS__KIAS_", goodItems.Average(item => item.s_Pri_AS__KIAS_), badItems.Average(item => item.s_Pri_AS__KIAS_)),
                    new Item("min_Prop_Speed__RPM_", goodItems.Average(item => item.min_Prop_Speed__RPM_), badItems.Average(item => item.min_Prop_Speed__RPM_)),
                    new Item("max_Prop_Speed__RPM_", goodItems.Average(item => item.max_Prop_Speed__RPM_), badItems.Average(item => item.max_Prop_Speed__RPM_)),
                    new Item("µ_Prop_Speed__RPM_", goodItems.Average(item => item.µ_Prop_Speed__RPM_), badItems.Average(item => item.µ_Prop_Speed__RPM_)),
                    new Item("s_Prop_Speed__RPM_", goodItems.Average(item => item.s_Prop_Speed__RPM_), badItems.Average(item => item.s_Prop_Speed__RPM_)),
                    new Item("min_Range__NM_", goodItems.Average(item => item.min_Range__NM_), badItems.Average(item => item.min_Range__NM_)),
                    new Item("max_Range__NM_", goodItems.Average(item => item.max_Range__NM_), badItems.Average(item => item.max_Range__NM_)),
                    new Item("µ_Range__NM_", goodItems.Average(item => item.µ_Range__NM_), badItems.Average(item => item.µ_Range__NM_)),
                    new Item("s_Range__NM_", goodItems.Average(item => item.s_Range__NM_), badItems.Average(item => item.s_Range__NM_)),

                    new Item("min_Roll_Rate__DEG_", goodItems.Average(item => item.min_Roll_Rate__DEG_), badItems.Average(item => item.min_Roll_Rate__DEG_)),
                    new Item("max_Roll_Rate__DEG_", goodItems.Average(item => item.max_Roll_Rate__DEG_), badItems.Average(item => item.max_Roll_Rate__DEG_)),
                    new Item("µ_Roll_Rate__DEG_", goodItems.Average(item => item.µ_Roll_Rate__DEG_), badItems.Average(item => item.µ_Roll_Rate__DEG_)),
                    new Item("s_Roll_Rate__DEG_", goodItems.Average(item => item.s_Roll_Rate__DEG_), badItems.Average(item => item.s_Roll_Rate__DEG_)),
                    new Item("µ_Tq_Loop_Health", goodItems.Average(item => item.µ_Tq_Loop_Health), badItems.Average(item => item.µ_Tq_Loop_Health)),
                    //new Item("OneCnt_Tq_Loop_Health", goodItems.Average(item => item.OneCnt_Tq_Loop_Health), badItems.Average(item => item.OneCnt_Tq_Loop_Health)),

                    new Item("min_Up_Sawtooth", goodItems.Average(item => item.min_Up_Sawtooth), badItems.Average(item => item.min_Up_Sawtooth)),
                    new Item("max_Up_Sawtooth", goodItems.Average(item => item.max_Up_Sawtooth), badItems.Average(item => item.max_Up_Sawtooth)),
                    new Item("µ_Up_Sawtooth", goodItems.Average(item => item.µ_Up_Sawtooth), badItems.Average(item => item.µ_Up_Sawtooth)),
                    new Item("s_Up_Sawtooth", goodItems.Average(item => item.s_Up_Sawtooth), badItems.Average(item => item.s_Up_Sawtooth)),
                    new Item("min_Wind_Dir__DEG_", goodItems.Average(item => item.min_Wind_Dir__DEG_), badItems.Average(item => item.min_Wind_Dir__DEG_)),
                    new Item("max_Wind_Dir__DEG_", goodItems.Average(item => item.max_Wind_Dir__DEG_), badItems.Average(item => item.max_Wind_Dir__DEG_)),
                    new Item("µ_Wind_Dir__DEG_", goodItems.Average(item => item.µ_Wind_Dir__DEG_), badItems.Average(item => item.µ_Wind_Dir__DEG_)),
                    new Item("s_Wind_Dir__DEG_", goodItems.Average(item => item.s_Wind_Dir__DEG_), badItems.Average(item => item.s_Wind_Dir__DEG_)),
                    new Item("min_Wind_Spd__kt_", goodItems.Average(item => item.min_Wind_Spd__kt_), badItems.Average(item => item.min_Wind_Spd__kt_)),
                    new Item("max_Wind_Spd__kt_", goodItems.Average(item => item.max_Wind_Spd__kt_), badItems.Average(item => item.max_Wind_Spd__kt_)),

                    new Item("µ_Wind_Spd__kt_", goodItems.Average(item => item.µ_Wind_Spd__kt_), badItems.Average(item => item.µ_Wind_Spd__kt_)),
                    new Item("s_Wind_Spd__kt_", goodItems.Average(item => item.s_Wind_Spd__kt_), badItems.Average(item => item.s_Wind_Spd__kt_)),
                    new Item("min_Yaw_Rate__DEG_", goodItems.Average(item => item.min_Yaw_Rate__DEG_), badItems.Average(item => item.min_Yaw_Rate__DEG_)),
                    new Item("max_Yaw_Rate__DEG_", goodItems.Average(item => item.max_Yaw_Rate__DEG_), badItems.Average(item => item.max_Yaw_Rate__DEG_)),
                    new Item("µ_Yaw_Rate__DEG_", goodItems.Average(item => item.µ_Yaw_Rate__DEG_), badItems.Average(item => item.µ_Yaw_Rate__DEG_)),
                    new Item("s_Yaw_Rate__DEG_", goodItems.Average(item => item.s_Yaw_Rate__DEG_), badItems.Average(item => item.s_Yaw_Rate__DEG_)),
                };

                Debug.WriteLine("There are {0} items on the list", _dataList.Count);

                var bindingList = new SortableBindingList<Item>(_dataList);
                var source = new BindingSource(bindingList, null);
                dataGridView.DataSource = source;

            }
        }
    }

    public class Item
    {
        public string Channel { get; private set; }
        public double? Good { get; private set; }
        public double? Bad { get; private set; }
        public double? Diff { get; private set; }

        public double? Absolute { get; private set; }

        public Item(string name, double? good, double? bad)
        {
            // TODO: Check for NULL
            Channel = name;
            Good    = good;
            Bad     = bad;
            Diff    = (Good - Bad) / Bad;

            if (Diff != null)
            {
                Absolute = Math.Abs((double) Diff);
            }
        }
    }
}
