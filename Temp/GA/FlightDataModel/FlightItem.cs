using System;

namespace FlightDataModel
{
    public class FlightItem
    {
        [System.ComponentModel.DisplayName("Fault ID")]
        public int FaultId { get; set; }
        public int Label { get; set; }
        public int? Tail { get; set; }
        [System.ComponentModel.DisplayName("Flight #")]
        public int? Flight { get; set; }
        [System.ComponentModel.DisplayName("Sequence #")]
        public int? Seq { get; set; }
        public string Version { get; set; }
        [System.ComponentModel.DisplayName("Flight Hours")]
        public double? FltHrs { get; set; }
        [System.ComponentModel.DisplayName("Flight Date")]
        public DateTime? FltDate { get; set; }
        public int? Count { get; set; }

        public double? m_Airspeed_hold_on { get; set; }
        public double? OneCnt_Airspeed_hold_on { get; set; }

        public double? min_Alt_MSL__ft_ { get; set; }
        public double? max_Alt_MSL__ft_ { get; set; }
        public double? m_Alt_MSL__ft_ { get; set; }
        public double? s_Alt_MSL__ft_ { get; set; }

        public double? m_Altitude_hold_on { get; set; }
        public double? OneCnt_Altitude_hold_on { get; set; }

        public double? m_Azimuth_hold_on { get; set; }
        public double? OneCnt_Azimuth_hold_on { get; set; }

        public double? min_Bat_2_Volt__V_ { get; set; }
        public double? max_Bat_2_Volt__V_ { get; set; }
        public double? m_Bat_2_Volt__V_ { get; set; }
        public double? s_Bat_2_Volt__V_ { get; set; }

        public double? m_Battery_leaking_current { get; set; }
        public double? OneCnt_Battery_leaking_current { get; set; }

        public double? min_Bus_1_Bat_Gnd_Amp__A_ { get; set; }
        public double? max_Bus_1_Bat_Gnd_Amp__A_ { get; set; }
        public double? m_Bus_1_Bat_Gnd_Amp__A_ { get; set; }
        public double? s_Bus_1_Bat_Gnd_Amp__A_ { get; set; }

        public double? min_Bus_1_Current__A_ { get; set; }
        public double? max_Bus_1_Current__A_ { get; set; }
        public double? m_Bus_1_Current__A_ { get; set; }
        public double? s_Bus_1_Current__A_ { get; set; }

        public double? min_Bus_1_Volt__V_ { get; set; }
        public double? max_Bus_1_Volt__V_ { get; set; }
        public double? m_Bus_1_Volt__V_ { get; set; }
        public double? s_Bus_1_Volt__V_ { get; set; }

        public double? min_Bus_2_Bat_Gnd_Amp__A_ { get; set; }
        public double? max_Bus_2_Bat_Gnd_Amp__A_ { get; set; }
        public double? m_Bus_2_Bat_Gnd_Amp__A_ { get; set; }
        public double? s_Bus_2_Bat_Gnd_Amp__A_ { get; set; }

        public double? min_Bus_2_Current__A_ { get; set; }
        public double? max_Bus_2_Current__A_ { get; set; }
        public double? m_Bus_2_Current__A_ { get; set; }
        public double? s_Bus_2_Current__A_ { get; set; }

        public double? min_Bus_2_Volt__V_ { get; set; }
        public double? max_Bus_2_Volt__V_ { get; set; }
        public double? m_Bus_2_Volt__V_ { get; set; }
        public double? s_Bus_2_Volt__V_ { get; set; }

        public double? min_Compass_Hdg__DEG_ { get; set; }
        public double? max_Compass_Hdg__DEG_ { get; set; }
        public double? m_Compass_Hdg__DEG_ { get; set; }
        public double? s_Compass_Hdg__DEG_ { get; set; }

        public double? min_DEEC_EGT__DEG_ { get; set; }
        public double? max_DEEC_EGT__DEG_ { get; set; }
        public double? m_DEEC_EGT__DEG_ { get; set; }
        public double? s_DEEC_EGT__DEG_ { get; set; }

        public double? min_DEEC_Torque { get; set; }
        public double? max_DEEC_Torque { get; set; }
        public double? m_DEEC_Torque { get; set; }
        public double? s_DEEC_Torque { get; set; }

        public double? min_Detent_Cmd { get; set; }
        public double? max_Detent_Cmd { get; set; }
        public double? m_Detent_Cmd { get; set; }
        public double? s_Detent_Cmd { get; set; }

        public double? min_Dn_Sawtooth { get; set; }
        public double? max_Dn_Sawtooth { get; set; }
        public double? m_Dn_Sawtooth { get; set; }
        public double? s_Dn_Sawtooth { get; set; }

        public double? min_EFIU_EGT__DEG_ { get; set; }
        public double? max_EFIU_EGT__DEG_ { get; set; }
        public double? m_EFIU_EGT__DEG_ { get; set; }
        public double? s_EFIU_EGT__DEG_ { get; set; }

        public double? min_EFIU_Torque { get; set; }
        public double? max_EFIU_Torque { get; set; }
        public double? m_EFIU_Torque { get; set; }
        public double? s_EFIU_Torque { get; set; }

        public double? min_Eng_Speed_Cmd { get; set; }
        public double? max_Eng_Speed_Cmd { get; set; }
        public double? m_Eng_Speed_Cmd { get; set; }
        public double? s_Eng_Speed_Cmd { get; set; }

        public double? min_Eng_Torque { get; set; }
        public double? max_Eng_Torque { get; set; }
        public double? m_Eng_Torque { get; set; }
        public double? s_Eng_Torque { get; set; }

        public double? m_GCU_inhibit { get; set; }
        public double? OneCnt_GCU_inhibit { get; set; }

        public double? m_GCU_reset { get; set; }
        public double? OneCnt_GCU_reset { get; set; }

        public double? min_GCU_Temp__DEG_ { get; set; }
        public double? max_GCU_Temp__DEG_ { get; set; }
        public double? m_GCU_Temp__DEG_ { get; set; }
        public double? s_GCU_Temp__DEG_ { get; set; }

        public double? min_Gen_Air_Temp__DEG_ { get; set; }
        public double? max_Gen_Air_Temp__DEG_ { get; set; }
        public double? m_Gen_Air_Temp__DEG_ { get; set; }
        public double? s_Gen_Air_Temp__DEG_ { get; set; }

        public double? min_Generator_Amp__A_ { get; set; }
        public double? max_Generator_Amp__A_ { get; set; }
        public double? m_Generator_Amp__A_ { get; set; }
        public double? s_Generator_Amp__A_ { get; set; }

        public double? min_GPS_Alt__ft_ { get; set; }
        public double? max_GPS_Alt__ft_ { get; set; }
        public double? m_GPS_Alt__ft_ { get; set; }
        public double? s_GPS_Alt__ft_ { get; set; }

        public double? m_In_flight_reset_detected_by_UAV { get; set; }
        public double? OneCnt_In_flight_reset_detected_by_UAV { get; set; }

        public double? min_Norm_Accel__g_ { get; set; }
        public double? max_Norm_Accel__g_ { get; set; }
        public double? m_Norm_Accel__g_ { get; set; }
        public double? s_Norm_Accel__g_ { get; set; }

        public double? min_OAT__DEG_ { get; set; }
        public double? max_OAT__DEG_ { get; set; }
        public double? m_OAT__DEG_ { get; set; }
        public double? s_OAT__DEG_ { get; set; }

        public double? min_Pitch_Rate__DEG_ { get; set; }
        public double? max_Pitch_Rate__DEG_ { get; set; }
        public double? m_Pitch_Rate__DEG_ { get; set; }
        public double? s_Pitch_Rate__DEG_ { get; set; }

        public double? min_PMA_Temp__DEG_ { get; set; }
        public double? max_PMA_Temp__DEG_ { get; set; }
        public double? m_PMA_Temp__DEG_ { get; set; }
        public double? s_PMA_Temp__DEG_ { get; set; }

        public double? min_Power_Cmd { get; set; }
        public double? max_Power_Cmd { get; set; }
        public double? m_Power_Cmd { get; set; }
        public double? s_Power_Cmd { get; set; }

        public double? min_Power_Gauge { get; set; }
        public double? max_Power_Gauge { get; set; }
        public double? m_Power_Gauge { get; set; }
        public double? s_Power_Gauge { get; set; }

        public double? min_Power_Lvr_Cmd { get; set; }
        public double? max_Power_Lvr_Cmd { get; set; }
        public double? m_Power_Lvr_Cmd { get; set; }
        public double? s_Power_Lvr_Cmd { get; set; }

        public double? m_Preprogrammed_mode_on { get; set; }
        public double? OneCnt_Preprogrammed_mode_on { get; set; }

        public double? min_Pri_AS__KIAS_ { get; set; }
        public double? max_Pri_AS__KIAS_ { get; set; }
        public double? m_Pri_AS__KIAS_ { get; set; }
        public double? s_Pri_AS__KIAS_ { get; set; }

        public double? min_Prop_Speed__RPM_ { get; set; }
        public double? max_Prop_Speed__RPM_ { get; set; }
        public double? m_Prop_Speed__RPM_ { get; set; }
        public double? s_Prop_Speed__RPM_ { get; set; }

        public double? min_Range__NM_ { get; set; }
        public double? max_Range__NM_ { get; set; }
        public double? m_Range__NM_ { get; set; }
        public double? s_Range__NM_ { get; set; }

        public double? min_Roll_Rate__DEG_ { get; set; }
        public double? max_Roll_Rate__DEG_ { get; set; }
        public double? m_Roll_Rate__DEG_ { get; set; }
        public double? s_Roll_Rate__DEG_ { get; set; }

        public string min_System_Amp__A_ { get; set; }
        public string max_System_Amp__A_ { get; set; }
        public string m_System_Amp__A_ { get; set; }
        public string s_System_Amp__A_ { get; set; }

        public double? m_Tq_Loop_Health { get; set; }
        public double? OneCnt_Tq_Loop_Health { get; set; }

        public double? min_Up_Sawtooth { get; set; }
        public double? max_Up_Sawtooth { get; set; }
        public double? m_Up_Sawtooth { get; set; }
        public double? s_Up_Sawtooth { get; set; }

        public double? min_Wind_Dir__DEG_ { get; set; }
        public double? max_Wind_Dir__DEG_ { get; set; }
        public double? m_Wind_Dir__DEG_ { get; set; }
        public double? s_Wind_Dir__DEG_ { get; set; }

        public double? min_Wind_Spd__kt_ { get; set; }
        public double? max_Wind_Spd__kt_ { get; set; }
        public double? m_Wind_Spd__kt_ { get; set; }
        public double? s_Wind_Spd__kt_ { get; set; }

        public double? min_Yaw_Rate__DEG_ { get; set; }
        public double? max_Yaw_Rate__DEG_ { get; set; }
        public double? m_Yaw_Rate__DEG_ { get; set; }
        public double? s_Yaw_Rate__DEG_ { get; set; }
    }
}
