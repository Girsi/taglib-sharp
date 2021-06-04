using System;

namespace TagLib.Mpeg
{
	/// <summary>
	///    Parses and holds the replay gain data of a LAME header.
	/// </summary>
	public struct LameReplayGainData
	{
		#region Enums

		/// <summary>
		///    Name of the adjustment.
		/// </summary>
		public enum AdjustmentName
		{
			/// <summary>
			///    Unknown
			/// </summary>
			Unknown,
			/// <summary>
			///    Not set
			/// </summary>
			NotSet,
			/// <summary>
			///    Radio
			/// </summary>
			Radio,
			/// <summary>
			///    Audiophile
			/// </summary>
			Audiophile
		}

		/// <summary>
		///    Originator of the adjustment.
		/// </summary>
		public enum AdjustmentOriginator
		{
			/// <summary>
			///    Unknown
			/// </summary>
			Unknown,
			/// <summary>
			///    Not set
			/// </summary>
			NotSet,
			/// <summary>
			///    Set by artist
			/// </summary>
			SetByArtist,
			/// <summary>
			///    Set by user
			/// </summary>
			SetByUser,
			/// <summary>
			///    Set by my model
			/// </summary>
			SetByMyModel,
			/// <summary>
			///    Set by Simple RMS average
			/// </summary>
			SetBySimpleRMSAverage
		}

		#endregion

		#region Constructor

		/// <summary>
		///    Constructs and initializes a new instance of <see
		///    cref="LameReplayGainData" /> by parsing the specified
		///    raw data.
		/// </summary>
		/// <param name="replay_gain_data">
		///    A <see cref="ByteVector" /> containing the raw
		///    replay gain data.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///    <paramref name="replay_gain_data" /> is
		///    <see langword="null" />.
		/// </exception>
		/// <exception cref="ArgumentException">
		///    <paramref name="replay_gain_data" /> is invalid.
		/// </exception>
		/// <exception cref="CorruptFileException">
		///    Parsing <paramref name="replay_gain_data" /> failed.
		/// </exception>
		public LameReplayGainData (ByteVector replay_gain_data)
		{
			if (replay_gain_data == null) {
				throw new ArgumentNullException (nameof (replay_gain_data));
			}

			if (replay_gain_data.Count != 8) {
				throw new ArgumentException ("Invalid data passed for LAME replay gain data parsing.", nameof(replay_gain_data));
			}

			PeakSignalAmlitude = replay_gain_data.Mid (0, 4).ToFloat ();

			RadioReplayGain_Name = ((replay_gain_data[4] >> 5 ) & 0x7) switch {
				0 => AdjustmentName.NotSet,
				1 => AdjustmentName.Radio,
				2 => AdjustmentName.Audiophile,
				_ => AdjustmentName.Unknown
			};

			if (RadioReplayGain_Name != AdjustmentName.NotSet && RadioReplayGain_Name != AdjustmentName.Radio) {
				throw new CorruptFileException ("Parsing LAME replay gain data failed: Expected radio adjustment data");
			}

			RadioReplayGain_Originator = ((replay_gain_data[4] >> 2) & 0x7) switch {
				0 => AdjustmentOriginator.NotSet,
				1 => AdjustmentOriginator.SetByArtist,
				2 => AdjustmentOriginator.SetByUser,
				3 => AdjustmentOriginator.SetBySimpleRMSAverage,
				_ => AdjustmentOriginator.Unknown
			};
			int radioReplayGain_SignBit = (replay_gain_data[4] >> 1) & 0x1;
			int radioReplayGain_AbsoluteGainAdjustment = ((replay_gain_data[4] & 0x1) << 8) + replay_gain_data[5];
			if (radioReplayGain_SignBit == 1) {
				radioReplayGain_AbsoluteGainAdjustment = -radioReplayGain_AbsoluteGainAdjustment;
			}
			RadioReplayGain_Adjustment = (float)radioReplayGain_AbsoluteGainAdjustment / 10;

			AudiophileReplayGain_Name = ((replay_gain_data[6] >> 5) & 0x7) switch {
				0 => AdjustmentName.NotSet,
				1 => AdjustmentName.Radio,
				2 => AdjustmentName.Audiophile,
				_ => AdjustmentName.Unknown
			};

			if (AudiophileReplayGain_Name != AdjustmentName.NotSet && AudiophileReplayGain_Name != AdjustmentName.Audiophile) {
				throw new CorruptFileException ("Parsing LAME replay gain data failed: Expected audiophile adjustment data");
			}

			AudiophileReplayGain_Originator = ((replay_gain_data[6] >> 2) & 0x7) switch {
				0 => AdjustmentOriginator.NotSet,
				1 => AdjustmentOriginator.SetByArtist,
				2 => AdjustmentOriginator.SetByUser,
				3 => AdjustmentOriginator.SetBySimpleRMSAverage,
				_ => AdjustmentOriginator.Unknown
			};
			int audiophileReplayGain_SignBit = (replay_gain_data[6] >> 1) & 0x1;
			int audiophileReplayGain_AbsoluteGainAdjustment = ((replay_gain_data[6] & 0x1) << 8) + replay_gain_data[7];
			if (audiophileReplayGain_SignBit == 1) {
				audiophileReplayGain_AbsoluteGainAdjustment = -audiophileReplayGain_AbsoluteGainAdjustment;
			}
			AudiophileReplayGain_Adjustment = (float)audiophileReplayGain_AbsoluteGainAdjustment / 10;
		}

		#endregion

		#region Public Properties

		/// <summary>
		///    Gets the peak signal amplitude found in the replay
		///    gain data.
		/// </summary>
		/// <value>
		///    A <see cref="float" /> object containing the peak
		///    signal amplitude, or <c>0</c> if not specified.
		/// </value>
		public float PeakSignalAmlitude { get; private set; }

		/// <summary>
		///    Gets the adjustment name for the radio gain
		///    adjustment found in the replay gain data.
		/// </summary>
		/// <value>
		///    A <see cref="AdjustmentName" /> value containing
		///    the name of the radio gain adjustment.
		/// </value>
		public AdjustmentName RadioReplayGain_Name { get; private set; }

		/// <summary>
		///    Gets the adjustment name for the radio gain
		///    originator found in the replay gain data.
		/// </summary>
		/// <value>
		///    A <see cref="AdjustmentOriginator" /> value containing
		///    the name of the radio gain originator.
		/// </value>
		public AdjustmentOriginator RadioReplayGain_Originator { get; private set; }

		/// <summary>
		///    Gets the value for the radio gain
		///    adjustment found in the replay gain data.
		/// </summary>
		/// <value>
		///    A <see cref="float" /> value containing
		///    the value of the radio gain adjustment.
		/// </value>
		public float RadioReplayGain_Adjustment { get; private set; }

		/// <summary>
		///    Gets the adjustment name for the audiophile gain
		///    adjustment found in the replay gain data.
		/// </summary>
		/// <value>
		///    A <see cref="AdjustmentName" /> value containing
		///    the name of the audiophile gain adjustment.
		/// </value>
		public AdjustmentName AudiophileReplayGain_Name { get; private set; }

		/// <summary>
		///    Gets the adjustment name for the audiophile gain
		///    originator found in the replay gain data.
		/// </summary>
		/// <value>
		///    A <see cref="AdjustmentOriginator" /> value containing
		///    the name of the audiophile gain originator.
		/// </value>
		public AdjustmentOriginator AudiophileReplayGain_Originator { get; private set; }

		/// <summary>
		///    Gets the value for the audiophile gain
		///    adjustment found in the replay gain data.
		/// </summary>
		/// <value>
		///    A <see cref="float" /> value containing
		///    the value of the audiophile gain adjustment.
		/// </value>
		public float AudiophileReplayGain_Adjustment { get; private set; }

		/// <summary>
		///    Gets whether or not any replay gain data is present in
		///    the file.
		/// </summary>
		/// <value>
		///    A <see cref="bool" /> value indicating whether or not any
		///    replay gain data is present.
		/// </value>
		public bool Present {
			get {
				return
					PeakSignalAmlitude != 0 ||
					RadioReplayGain_Name != AdjustmentName.NotSet ||
					RadioReplayGain_Originator != AdjustmentOriginator.NotSet ||
					RadioReplayGain_Adjustment != 0 ||
					AudiophileReplayGain_Name != AdjustmentName.NotSet ||
					AudiophileReplayGain_Originator != AdjustmentOriginator.NotSet ||
					AudiophileReplayGain_Adjustment != 0;
			}
		}

		#endregion
	}
}
