using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using FlightDataModel;

namespace WindowsFormsClientApplication
{
    sealed class CsvFileDefinitionMap : CsvClassMap<FlightItem>
    {
        public CsvFileDefinitionMap()
        {
            Map(m => m.FaultId).Name("FaultId");
            Map(m => m.Label).Name("Label");
            Map(m => m.Tail).Name("TAIL");
            Map(m => m.Flight).Name("Flight");
            Map(m => m.Seq).Name("Seq#");
            Map(m => m.Version).Name("version");
            Map(m => m.FltHrs).Name("FltHrs");
            Map(m => m.FltDate).Name("FltDate");
            Map(m => m.Count).Name("Count");
            Map(m => m.Seq).Name("Seq#");

            Map(m => m.m_Airspeed_hold_on).Name("m_Airspeed_hold_on");
            Map(m => m.OneCnt_Airspeed_hold_on).Name("OneCnt_Airspeed_hold_on");

            Map(m => m.min_Alt_MSL__ft_).Name("min_Alt_MSL__ft_");
            Map(m => m.max_Alt_MSL__ft_).Name("max_Alt_MSL__ft_");
            Map(m => m.m_Alt_MSL__ft_).Name("m_Alt_MSL__ft_");
            Map(m => m.s_Alt_MSL__ft_).Name("s_Alt_MSL__ft_");

            Map(m => m.m_Altitude_hold_on).Name("m_Altitude_hold_on");
            Map(m => m.OneCnt_Altitude_hold_on).Name("OneCnt_Altitude_hold_on");

            Map(m => m.m_Azimuth_hold_on).Name("m_Azimuth_hold_on");
            Map(m => m.OneCnt_Azimuth_hold_on).Name("OneCnt_Azimuth_hold_on");

            Map(m => m.min_Bat_2_Volt__V_).Name("min_Bat_2_Volt__V_");
            Map(m => m.max_Bat_2_Volt__V_).Name("max_Bat_2_Volt__V_");
            Map(m => m.m_Bat_2_Volt__V_).Name("m_Bat_2_Volt__V_");
            Map(m => m.s_Bat_2_Volt__V_).Name("s_Bat_2_Volt__V_");
            Map(m => m.m_Battery_leaking_current).Name("m_Battery_leaking_current.");
            Map(m => m.OneCnt_Battery_leaking_current).Name("OneCnt_Battery_leaking_current.");

            Map(m => m.min_Bus_1_Bat_Gnd_Amp__A_).Name("min_Bus_1_Bat_Gnd_Amp__A_");
            Map(m => m.max_Bus_1_Bat_Gnd_Amp__A_).Name("max_Bus_1_Bat_Gnd_Amp__A_");
            Map(m => m.m_Bus_1_Bat_Gnd_Amp__A_).Name("m_Bus_1_Bat_Gnd_Amp__A_");
            Map(m => m.s_Bus_1_Bat_Gnd_Amp__A_).Name("s_Bus_1_Bat_Gnd_Amp__A_");

            Map(m => m.min_Bus_1_Current__A_).Name("min_Bus_1_Current__A_");
            Map(m => m.max_Bus_1_Current__A_).Name("max_Bus_1_Current__A_");
            Map(m => m.m_Bus_1_Current__A_).Name("m_Bus_1_Current__A_");
            Map(m => m.s_Bus_1_Current__A_).Name("s_Bus_1_Current__A_");

            Map(m => m.min_Bus_1_Volt__V_).Name("min_Bus_1_Volt__V_");
            Map(m => m.max_Bus_1_Volt__V_).Name("max_Bus_1_Volt__V_");
            Map(m => m.m_Bus_1_Volt__V_).Name("m_Bus_1_Volt__V_");
            Map(m => m.s_Bus_1_Volt__V_).Name("s_Bus_1_Volt__V_");

            Map(m => m.min_Bus_2_Bat_Gnd_Amp__A_).Name("min_Bus_2_Bat_Gnd_Amp__A_");
            Map(m => m.max_Bus_2_Bat_Gnd_Amp__A_).Name("max_Bus_2_Bat_Gnd_Amp__A_");
            Map(m => m.m_Bus_2_Bat_Gnd_Amp__A_).Name("m_Bus_2_Bat_Gnd_Amp__A_");
            Map(m => m.s_Bus_2_Bat_Gnd_Amp__A_).Name("s_Bus_2_Bat_Gnd_Amp__A_");

            Map(m => m.min_Bus_2_Current__A_).Name("min_Bus_2_Current__A_");
            Map(m => m.max_Bus_2_Current__A_).Name("max_Bus_2_Current__A_");
            Map(m => m.m_Bus_2_Current__A_).Name("m_Bus_2_Current__A_");
            Map(m => m.s_Bus_2_Current__A_).Name("s_Bus_2_Current__A_");

            Map(m => m.min_Bus_2_Volt__V_).Name("min_Bus_2_Volt__V_");
            Map(m => m.max_Bus_2_Volt__V_).Name("max_Bus_2_Volt__V_");
            Map(m => m.m_Bus_2_Volt__V_).Name("m_Bus_2_Volt__V_");
            Map(m => m.s_Bus_2_Volt__V_).Name("s_Bus_2_Volt__V_");

            Map(m => m.min_Compass_Hdg__DEG_).Name("min_Compass_Hdg__DEG_");
            Map(m => m.max_Compass_Hdg__DEG_).Name("max_Compass_Hdg__DEG_");
            Map(m => m.m_Compass_Hdg__DEG_).Name("m_Compass_Hdg__DEG_");
            Map(m => m.s_Compass_Hdg__DEG_).Name("s_Compass_Hdg__DEG_");

            Map(m => m.min_DEEC_EGT__DEG_).Name("min_DEEC_EGT__DEG_");
            Map(m => m.max_DEEC_EGT__DEG_).Name("max_DEEC_EGT__DEG_");
            Map(m => m.m_DEEC_EGT__DEG_).Name("m_DEEC_EGT__DEG_");
            Map(m => m.s_DEEC_EGT__DEG_).Name("s_DEEC_EGT__DEG_");

            Map(m => m.min_DEEC_Torque).Name("min_DEEC_Torque");
            Map(m => m.max_DEEC_Torque).Name("max_DEEC_Torque");
            Map(m => m.m_DEEC_Torque).Name("m_DEEC_Torque");
            Map(m => m.s_DEEC_Torque).Name("s_DEEC_Torque");

            Map(m => m.min_Detent_Cmd).Name("min_Detent_Cmd");
            Map(m => m.max_Detent_Cmd).Name("max_Detent_Cmd");
            Map(m => m.m_Detent_Cmd).Name("m_Detent_Cmd");
            Map(m => m.s_Detent_Cmd).Name("s_Detent_Cmd");

            Map(m => m.min_Dn_Sawtooth).Name("min_Dn_Sawtooth");
            Map(m => m.max_Dn_Sawtooth).Name("max_Dn_Sawtooth");
            Map(m => m.m_Dn_Sawtooth).Name("m_Dn_Sawtooth");
            Map(m => m.s_Dn_Sawtooth).Name("s_Dn_Sawtooth");

            Map(m => m.min_EFIU_EGT__DEG_).Name("min_EFIU_EGT__DEG_");
            Map(m => m.max_EFIU_EGT__DEG_).Name("max_EFIU_EGT__DEG_");
            Map(m => m.m_EFIU_EGT__DEG_).Name("m_EFIU_EGT__DEG_");
            Map(m => m.s_EFIU_EGT__DEG_).Name("s_EFIU_EGT__DEG_");

            Map(m => m.min_EFIU_Torque).Name("min_EFIU_Torque");
            Map(m => m.max_EFIU_Torque).Name("max_EFIU_Torque");
            Map(m => m.m_EFIU_Torque).Name("m_EFIU_Torque");
            Map(m => m.s_EFIU_Torque).Name("s_EFIU_Torque");

            Map(m => m.min_Eng_Speed_Cmd).Name("min_Eng_Speed_Cmd");
            Map(m => m.max_Eng_Speed_Cmd).Name("max_Eng_Speed_Cmd");
            Map(m => m.m_Eng_Speed_Cmd).Name("m_Eng_Speed_Cmd");
            Map(m => m.s_Eng_Speed_Cmd).Name("s_Eng_Speed_Cmd");

            Map(m => m.min_Eng_Torque).Name("min_Eng_Torque");
            Map(m => m.max_Eng_Torque).Name("max_Eng_Torque");
            Map(m => m.m_Eng_Torque).Name("m_Eng_Torque");
            Map(m => m.s_Eng_Torque).Name("s_Eng_Torque");

            Map(m => m.m_GCU_inhibit).Name("m_GCU_inhibit");
            Map(m => m.OneCnt_GCU_inhibit).Name("OneCnt_GCU_inhibit");

            Map(m => m.m_GCU_reset).Name("m_GCU_reset");
            Map(m => m.OneCnt_GCU_reset).Name("OneCnt_GCU_reset");

            Map(m => m.min_GCU_Temp__DEG_).Name("min_GCU_Temp__DEG_");
            Map(m => m.max_GCU_Temp__DEG_).Name("max_GCU_Temp__DEG_");
            Map(m => m.m_GCU_Temp__DEG_).Name("m_GCU_Temp__DEG_");
            Map(m => m.s_GCU_Temp__DEG_).Name("s_GCU_Temp__DEG_");

            Map(m => m.min_Gen_Air_Temp__DEG_).Name("min_Gen_Air_Temp__DEG_");
            Map(m => m.max_Gen_Air_Temp__DEG_).Name("max_Gen_Air_Temp__DEG_");
            Map(m => m.m_Gen_Air_Temp__DEG_).Name("m_Gen_Air_Temp__DEG_");
            Map(m => m.s_Gen_Air_Temp__DEG_).Name("s_Gen_Air_Temp__DEG_");

            Map(m => m.min_Generator_Amp__A_).Name("min_Generator_Amp__A_");
            Map(m => m.max_Generator_Amp__A_).Name("max_Generator_Amp__A_");
            Map(m => m.m_Generator_Amp__A_).Name("m_Generator_Amp__A_");
            Map(m => m.s_Generator_Amp__A_).Name("s_Generator_Amp__A_");

            Map(m => m.min_GPS_Alt__ft_).Name("min_GPS_Alt__ft_");
            Map(m => m.max_GPS_Alt__ft_).Name("max_GPS_Alt__ft_");
            Map(m => m.m_GPS_Alt__ft_).Name("m_GPS_Alt__ft_");
            Map(m => m.s_GPS_Alt__ft_).Name("s_GPS_Alt__ft_");

            Map(m => m.m_In_flight_reset_detected_by_UAV).Name("m_In_flight_reset_detected_by_UAV");
            Map(m => m.OneCnt_In_flight_reset_detected_by_UAV).Name("OneCnt_In_flight_reset_detected_by_UAV");

            Map(m => m.min_Norm_Accel__g_).Name("min_Norm_Accel__g_");
            Map(m => m.max_Norm_Accel__g_).Name("max_Norm_Accel__g_");
            Map(m => m.m_Norm_Accel__g_).Name("m_Norm_Accel__g_");
            Map(m => m.s_Norm_Accel__g_).Name("s_Norm_Accel__g_");

            Map(m => m.min_OAT__DEG_).Name("min_OAT__DEG_");
            Map(m => m.max_OAT__DEG_).Name("max_OAT__DEG_");
            Map(m => m.m_OAT__DEG_).Name("m_OAT__DEG_");
            Map(m => m.s_OAT__DEG_).Name("s_OAT__DEG_");

            Map(m => m.min_Pitch_Rate__DEG_).Name("min_Pitch_Rate__DEG_");
            Map(m => m.max_Pitch_Rate__DEG_).Name("max_Pitch_Rate__DEG_");
            Map(m => m.m_Pitch_Rate__DEG_).Name("m_Pitch_Rate__DEG_");
            Map(m => m.s_Pitch_Rate__DEG_).Name("s_Pitch_Rate__DEG_");

            Map(m => m.min_PMA_Temp__DEG_).Name("min_PMA_Temp__DEG_");
            Map(m => m.max_PMA_Temp__DEG_).Name("max_PMA_Temp__DEG_");
            Map(m => m.m_PMA_Temp__DEG_).Name("m_PMA_Temp__DEG_");
            Map(m => m.s_PMA_Temp__DEG_).Name("s_PMA_Temp__DEG_");

            Map(m => m.min_Power_Cmd).Name("min_Power_Cmd");
            Map(m => m.max_Power_Cmd).Name("max_Power_Cmd");
            Map(m => m.m_Power_Cmd).Name("m_Power_Cmd");
            Map(m => m.s_Power_Cmd).Name("s_Power_Cmd");

            Map(m => m.min_Power_Gauge).Name("min_Power_Gauge");
            Map(m => m.max_Power_Gauge).Name("max_Power_Gauge");
            Map(m => m.m_Power_Gauge).Name("m_Power_Gauge");
            Map(m => m.s_Power_Gauge).Name("s_Power_Gauge");

            Map(m => m.min_Power_Lvr_Cmd).Name("min_Power_Lvr_Cmd");
            Map(m => m.max_Power_Lvr_Cmd).Name("max_Power_Lvr_Cmd");
            Map(m => m.m_Power_Lvr_Cmd).Name("m_Power_Lvr_Cmd");
            Map(m => m.s_Power_Lvr_Cmd).Name("s_Power_Lvr_Cmd");

            Map(m => m.m_Preprogrammed_mode_on).Name("m_Preprogrammed_mode_on");
            Map(m => m.OneCnt_Preprogrammed_mode_on).Name("OneCnt_Preprogrammed_mode_on");

            Map(m => m.min_Pri_AS__KIAS_).Name("min_Pri_AS__KIAS_");
            Map(m => m.max_Pri_AS__KIAS_).Name("max_Pri_AS__KIAS_");
            Map(m => m.m_Pri_AS__KIAS_).Name("m_Pri_AS__KIAS_");
            Map(m => m.s_Pri_AS__KIAS_).Name("s_Pri_AS__KIAS_");

            Map(m => m.min_Prop_Speed__RPM_).Name("min_Prop_Speed__RPM_");
            Map(m => m.max_Prop_Speed__RPM_).Name("max_Prop_Speed__RPM_");
            Map(m => m.m_Prop_Speed__RPM_).Name("m_Prop_Speed__RPM_");
            Map(m => m.s_Prop_Speed__RPM_).Name("s_Prop_Speed__RPM_");

            Map(m => m.min_Range__NM_).Name("min_Range__NM_");
            Map(m => m.max_Range__NM_).Name("max_Range__NM_");
            Map(m => m.m_Range__NM_).Name("m_Range__NM_");
            Map(m => m.s_Range__NM_).Name("s_Range__NM_");

            Map(m => m.min_Roll_Rate__DEG_).Name("min_Roll_Rate__DEG_");
            Map(m => m.max_Roll_Rate__DEG_).Name("max_Roll_Rate__DEG_");
            Map(m => m.m_Roll_Rate__DEG_).Name("m_Roll_Rate__DEG_");
            Map(m => m.s_Roll_Rate__DEG_).Name("s_Roll_Rate__DEG_");

            Map(m => m.min_System_Amp__A_).Name("min_System_Amp__A_");
            Map(m => m.max_System_Amp__A_).Name("max_System_Amp__A_");
            Map(m => m.m_System_Amp__A_).Name("m_System_Amp__A_");
            Map(m => m.s_System_Amp__A_).Name("s_System_Amp__A_");

            Map(m => m.m_Tq_Loop_Health).Name("m_Tq_Loop_Health");
            Map(m => m.OneCnt_Tq_Loop_Health).Name("OneCnt_Tq_Loop_Health");

            Map(m => m.min_Up_Sawtooth).Name("min_Up_Sawtooth");
            Map(m => m.max_Up_Sawtooth).Name("max_Up_Sawtooth");
            Map(m => m.m_Up_Sawtooth).Name("m_Up_Sawtooth");
            Map(m => m.s_Up_Sawtooth).Name("s_Up_Sawtooth");

            Map(m => m.min_Wind_Dir__DEG_).Name("min_Wind_Dir__DEG_");
            Map(m => m.max_Wind_Dir__DEG_).Name("max_Wind_Dir__DEG_");
            Map(m => m.m_Wind_Dir__DEG_).Name("m_Wind_Dir__DEG_");
            Map(m => m.s_Wind_Dir__DEG_).Name("s_Wind_Dir__DEG_");

            Map(m => m.min_Wind_Spd__kt_).Name("min_Wind_Spd__kt_");
            Map(m => m.max_Wind_Spd__kt_).Name("max_Wind_Spd__kt_");
            Map(m => m.m_Wind_Spd__kt_).Name("m_Wind_Spd__kt_");
            Map(m => m.s_Wind_Spd__kt_).Name("s_Wind_Spd__kt_");

            Map(m => m.min_Yaw_Rate__DEG_).Name("min_Yaw_Rate__DEG_");
            Map(m => m.max_Yaw_Rate__DEG_).Name("max_Yaw_Rate__DEG_");
            Map(m => m.m_Yaw_Rate__DEG_).Name("m_Yaw_Rate__DEG_");
            Map(m => m.s_Yaw_Rate__DEG_).Name("s_Yaw_Rate__DEG_");
        }
    }
}
