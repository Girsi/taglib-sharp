using System;

namespace TagLib.Mpeg
{
	#region Enums

	/// <summary>
	///    Indicates the VBR method of a file.
	/// </summary>
	public enum VBRMethod
	{
		/// <summary>
		///    Unknown
		/// </summary>
		Unknown,
		/// <summary>
		///    Constant bitrate
		/// </summary>
		CBR,
		/// <summary>
		///    Restricted VBR targetting a given average bitrate (ABR)
		/// </summary>
		ABR,
		/// <summary>
		///    Full VBR method 1
		/// </summary>
		FullVBR1,
		/// <summary>
		///    Full VBR method 2
		/// </summary>
		FullVBR2,
		/// <summary>
		///    Full VBR method 2
		/// </summary>
		FullVBR3,
		/// <summary>
		///    Full VBR method 4
		/// </summary>
		FullVBR4,
		/// <summary>
		///    Constant bitrate 2 pass
		/// </summary>
		CBR2Pass,
		/// <summary>
		///    ABR 2 pass
		/// </summary>
		ABR2Pass
	}

	/// <summary>
	///    Indicates the LAME specific VBR method of a file.
	/// </summary>
	public enum LameVBRMethod
	{
		/// <summary>
		///    Unknown
		/// </summary>
		Unknown,
		/// <summary>
		///    ABR
		/// </summary>
		ABR,
		/// <summary>
		///    VBR Old (rht)
		/// </summary>
		VBROldRH,
		/// <summary>
		///    VBR (mtrh)
		/// </summary>
		VBRMTRH,
		/// <summary>
		///    VBR (mt)
		/// </summary>
		VBRMT
	}

	/// <summary>
	///     Indicates the Stereo mode.
	/// </summary>
	public enum LameStereoMode
	{
		/// <summary>
		///    Mono
		/// </summary>
		Mono,
		/// <summary>
		///    Stereo
		/// </summary>
		Stereo,
		/// <summary>
		///    Dual
		/// </summary>
		Dual,
		/// <summary>
		///    Joint
		/// </summary>
		Joint,
		/// <summary>
		///    Force
		/// </summary>
		Force,
		/// <summary>
		///    Auto
		/// </summary>
		Auto,
		/// <summary>
		///    Intensity
		/// </summary>
		Intensity,
		/// <summary>
		///    Unddefined or different
		/// </summary>
		UndefinedOrDifferent
	}

	/// <summary>
	///     Indicates the source (not mp3) sampe frequency.
	/// </summary>
	public enum LameSourceSampleFrequency
	{
		/// <summary>
		///    32kHz or smaller
		/// </summary>
		Freq32kHzOrSmaller,
		/// <summary>
		///    44.1kHz
		/// </summary>
		FreqF44_1kHz,
		/// <summary>
		///    48kHz
		/// </summary>
		Freq48KHz,
		/// <summary>
		///    higher than 48kHz
		/// </summary>
		FreqHigherThan48kHz,
		/// <summary>
		///    Unknown value
		/// </summary>
		UnknownValue
	}

	/// <summary>
	///     Indicates the surround info.
	/// </summary>
	public enum LameSurroundEncodingInfo
	{
		/// <summary>
		///    No surroung
		/// </summary>
		NoSurround,
		/// <summary>
		///    DPL encoding
		/// </summary>
		DPL,
		/// <summary>
		///    DPL2 encoding
		/// </summary>
		DPL2,
		/// <summary>
		///    Ambisonic encoding
		/// </summary>
		Ambisonic,
		/// <summary>
		///    Unknown Value
		/// </summary>
		UnknownValue
	}

	/// <summary>
	///     Indicates the LAME preset mode. Taken from LAME header.
	/// </summary>
	public enum LamePresetMode
	{
		/*values from 8 to 320 should be reserved for abr bitrates*/
		/*for abr I'd suggest to directly use the targeted bitrate as a value*/
		/// <summary>
		///    ABR 8
		/// </summary>
		ABR_8 = 8,
		/// <summary>
		///    ABR 320
		/// </summary>
		ABR_320 = 320,

		/// <summary>
		///    V9
		/// </summary>
		V9 = 410, /*Vx to match Lame and VBR_xx to match FhG*/
		/// <summary>
		///    VBR 10
		/// </summary>
		VBR_10 = 410,
		/// <summary>
		///    V8
		/// </summary>
		V8 = 420,
		/// <summary>
		///    VBR 20
		/// </summary>
		VBR_20 = 420,
		/// <summary>
		///    V7
		/// </summary>
		V7 = 430,
		/// <summary>
		///    VBR 30
		/// </summary>
		VBR_30 = 430,
		/// <summary>
		///    V6
		/// </summary>
		V6 = 440,
		/// <summary>
		///    VBR 40
		/// </summary>
		VBR_40 = 440,
		/// <summary>
		///    V5
		/// </summary>
		V5 = 450,
		/// <summary>
		///    VBR 50
		/// </summary>
		VBR_50 = 450,
		/// <summary>
		///    V4
		/// </summary>
		V4 = 460,
		/// <summary>
		///    VBR 60
		/// </summary>
		VBR_60 = 460,
		/// <summary>
		///    V3
		/// </summary>
		V3 = 470,
		/// <summary>
		///    VBR 70
		/// </summary>
		VBR_70 = 470,
		/// <summary>
		///    V2
		/// </summary>
		V2 = 480,
		/// <summary>
		///    VBR 80
		/// </summary>
		VBR_80 = 480,
		/// <summary>
		///    V1
		/// </summary>
		V1 = 490,
		/// <summary>
		///    VBR 90
		/// </summary>
		VBR_90 = 490,
		/// <summary>
		///    V0
		/// </summary>
		V0 = 500,
		/// <summary>
		///    VBR 100
		/// </summary>
		VBR_100 = 500,



		/*still there for compatibility*/
		/// <summary>
		///    R3mix
		/// </summary>
		R3MIX = 1000,
		/// <summary>
		///    Standard
		/// </summary>
		STANDARD = 1001,
		/// <summary>
		///    Extreme
		/// </summary>
		EXTREME = 1002,
		/// <summary>
		///    Insane
		/// </summary>
		INSANE = 1003,
		/// <summary>
		///    Standard fast
		/// </summary>
		STANDARD_FAST = 1004,
		/// <summary>
		///    Extreme fast
		/// </summary>
		EXTREME_FAST = 1005,
		/// <summary>
		///    Medium
		/// </summary>
		MEDIUM = 1006,
		/// <summary>
		///    Medium Fast
		/// </summary>
		MEDIUM_FAST = 1007
	}

	#endregion

	/// <summary>
	///    This structure provides information about a variable bitrate MPEG
	///    audio stream, as used by the LAME encoder.
	/// </summary>
	public struct LameHeader
	{
		#region Private Fields

		long _audioHeaderStartPosition;

		#endregion

		#region Constructors

		/// <summary>
		///    Constructs and initializes a new instance of <see
		///    cref="LameHeader" /> by reading its raw contents.
		/// </summary>
		/// <param name="file">
		///    A <see cref="TagLib.File" /> object to read the LAME
		///    header from.
		/// </param>
		/// <param name="audioHeaderStartPosition">
		///    A <see cref="long" /> value specifying the start
		///    position of the audio header in <paramref name="file" />.
		/// </param>
		/// <param name="lameHeaderPositionAfterEncoderData">
		///    A <see cref="long" /> value specifying the position
		///    in <paramref name="file" /> after the LAME encoder data.
		/// </param>
		/// <param name="encoderVersion">
		///    A <see cref="string" /> value specifying the encoder
		///    version of the LAME header.
		/// </param>
		/// <param name="qualityIndicator">
		///    A <see cref="uint" /> value containing the quality
		///    indicator value of the xing header of the file, or
		///    <see langword="null" /> if not specified.
		/// </param>
		/// <exception cref="CorruptFileException">
		///    Parsing <paramref name="file" /> failed.
		/// </exception>
		private LameHeader (TagLib.File file, long audioHeaderStartPosition, long lameHeaderPositionAfterEncoderData, string encoderVersion, uint? qualityIndicator)
		{
			_audioHeaderStartPosition = audioHeaderStartPosition;
			EncoderVersion = encoderVersion;

			if (qualityIndicator != null)
			{
				uint indicator = qualityIndicator.Value;

				uint? vbr_value;
				uint? q_value;

				if (indicator == 100) {
					vbr_value = 0;
					q_value = 0;
				} else if (indicator >= 10 && indicator <= 99) {
					uint firstDigit = (indicator / 10) % 10;
					uint secondDigit = indicator % 10;

					if (secondDigit == 0) {
						q_value = 0;
					} else {
						q_value = 10 - secondDigit;
					}

					vbr_value = 10 - firstDigit;
					if (q_value > 0) {
						--vbr_value;
					}
				} else if (indicator > 0 && indicator < 10) {
					uint digit = indicator % 10;

					if (digit == 0) {
						q_value = 0;
					} else {
						q_value = 10 - digit;
					}

					vbr_value = 9;
				} else {
					vbr_value = null;
					q_value = null;
				}

				VBRValue = vbr_value;
				QValue = q_value;
			} else {
				VBRValue = null;
				QValue = null;
			}

			file.Seek (lameHeaderPositionAfterEncoderData);

			ByteVector header_data = file.ReadBlock (27);
			if (header_data.Count != 27) {
				throw new CorruptFileException ("Reading LAME header data failed.");
			}

			LameTagRevision = header_data[0] & 0xF0;

			VBRMethod = (header_data[0] & 0xF) switch {
				0 => VBRMethod.Unknown,
				1 => VBRMethod.CBR,
				2 => VBRMethod.ABR,
				3 => VBRMethod.FullVBR1,
				4 => VBRMethod.FullVBR2,
				5 => VBRMethod.FullVBR3,
				6 => VBRMethod.FullVBR4,
				8 => VBRMethod.CBR2Pass,
				9 => VBRMethod.ABR2Pass,
				_ => VBRMethod.Unknown,
			};

			LameVBRMethod = VBRMethod switch {
				VBRMethod.ABR => LameVBRMethod.ABR,
				VBRMethod.FullVBR1 => LameVBRMethod.VBROldRH,
				VBRMethod.FullVBR2 => LameVBRMethod.VBRMTRH,
				VBRMethod.FullVBR3 => LameVBRMethod.VBRMT,
				_ => LameVBRMethod.Unknown,
			};

			LowpassFilter = header_data[1] * 100; // in Hz

			LameReplayGainData = new (header_data.Mid (2, 8));

			NSPsytuneUsed = (header_data[10] & 0x10) == 0x10;
			NSSafeJointUsed = (header_data[10] & 0x20) == 0x20;
			IsNoGapContinued = (header_data[10] & 0x40) == 0x40;
			IsNoGapContinuation = (header_data[10] & 0x80) == 0x80;

			ATHType = header_data[10] & 0xF;

			BitrateValue = header_data[11];

			switch (VBRMethod) {
			case VBRMethod.Unknown:
				BitrateValueDescription = "Unknown VBRMethod, cannot give description";
				break;
			case VBRMethod.CBR:
				BitrateValueDescription = $"CBR bitrate: {BitrateValue} kbit/s";
				break;
			case VBRMethod.ABR:
				if (BitrateValue == 0) {
					BitrateValueDescription = "ABR bitrate unknown";
				} else {
					BitrateValueDescription = $"Specified bitrate (--abr): {BitrateValue} kbit/s";
				}
				break;
			case VBRMethod.FullVBR1:
				BitrateValueDescription = $"Minimal VBR bitrate: {BitrateValue} kbit/s";
				break;
			case VBRMethod.FullVBR2:
				goto case VBRMethod.FullVBR1;
			case VBRMethod.FullVBR3:
				goto case VBRMethod.FullVBR1;
			case VBRMethod.FullVBR4:
				goto case VBRMethod.FullVBR1;
			case VBRMethod.CBR2Pass:
				goto case VBRMethod.CBR;
			case VBRMethod.ABR2Pass:
				goto case VBRMethod.ABR;
			default:
				goto case VBRMethod.Unknown;
			}

			EncoderDelay = (header_data[12] << 4) + (header_data[13] & 0xF0);

			EncoderPadding = ((header_data[13] & 0xF) << 8) + header_data[14];

			NoiseShaping = header_data[15] & 0x3;

			LameStereoMode = ((header_data[15] >> 2) & 0x3) switch {
				0 => LameStereoMode.Mono,
				1 => LameStereoMode.Stereo,
				2 => LameStereoMode.Dual,
				3 => LameStereoMode.Joint,
				4 => LameStereoMode.Force,
				5 => LameStereoMode.Auto,
				6 => LameStereoMode.Intensity,
				_ => LameStereoMode.UndefinedOrDifferent,
			};

			UnwiseSettingsUsed = ((header_data[15] >> 5) & 0x1) == 0x1;

			LameSourceSampleFrequency = ((header_data[15] >> 6) & 0x3) switch {
				0 => LameSourceSampleFrequency.Freq32kHzOrSmaller,
				1 => LameSourceSampleFrequency.FreqF44_1kHz,
				2 => LameSourceSampleFrequency.Freq48KHz,
				3 => LameSourceSampleFrequency.FreqHigherThan48kHz,
				_ => LameSourceSampleFrequency.UnknownValue
			};

			int mp3GainValue = header_data[16] & 0x7F;
			if ((header_data[16] & 0x80) == 0x80) {
				mp3GainValue = -mp3GainValue;
			}

			Mp3GainValue = (sbyte)mp3GainValue;
			Mp3GainAmplificationFactor = Math.Pow (2, mp3GainValue * 0.25);
			Mp3GainDecibelChange = mp3GainValue * 1.5;

			LameSurroundEncodingInfo = ((header_data[17] >> 3) & 0x7) switch {
				0 => LameSurroundEncodingInfo.NoSurround,
				1 => LameSurroundEncodingInfo.DPL,
				2 => LameSurroundEncodingInfo.DPL2,
				3 => LameSurroundEncodingInfo.Ambisonic,
				_ => LameSurroundEncodingInfo.UnknownValue
			};

			LamePresetMode = (LamePresetMode)(((header_data[17] & 0x7) << 8) + header_data[18]);

			MusicLength =
				(header_data[19] << 24) +
				(header_data[20] << 16) +
				(header_data[21] << 8) +
				(header_data[22]);

			MusicCRC = header_data.Mid (23, 2).ToUShort ();

			InfoTagCRC = header_data.Mid (25, 2).ToUShort ();
		}

		#endregion

		#region Public Properties

		/// <summary>
		///    Gets the encoder version of the file, as indicated by the
		///    current instance.
		/// </summary>
		/// <value>
		///    A <see cref="string" /> value indicating the
		///    encoder of the file.
		/// </value>
		public string EncoderVersion { get; private set; }

		/// <summary>
		///    Gets the VBR value derived from the
		///    <see cref="XingHeader.QualityIndicator" /> of the file, as
		///    indicated by the current instance.
		/// </summary>
		/// <value>
		///    A <see cref="uint" /> value containing the VBR value
		///    derived from the <see cref="XingHeader.QualityIndicator" />
		///    of the file, or <see langword="null" /> if no
		///    <see cref="XingHeader.QualityIndicator" /> is specified or
		///    has an unexpected value.
		/// </value>
		public uint? VBRValue { get; private set; }

		/// <summary>
		///    Gets the Q value derived from the
		///    <see cref="XingHeader.QualityIndicator" /> of the file, as
		///    indicated by the current instance.
		/// </summary>
		/// <value>
		///    A <see cref="uint" /> value containing the Q value
		///    derived from the <see cref="XingHeader.QualityIndicator" />
		///    of the file, or <see langword="null" /> if no
		///    <see cref="XingHeader.QualityIndicator" /> is specified or
		///    has an unexpected value.
		/// </value>
		public uint? QValue { get; private set; }

		/// <summary>
		///    Gets the LAME tag revision of the file, as indicated
		///    by the current instance.
		/// </summary>
		/// <value>
		///    A <see cref="int" /> value containing the LAME tag
		///    revision of the file.
		/// </value>
		public int LameTagRevision { get; private set; }

		/// <summary>
		///    Gets the VBR method of the file, as indicated by the
		///    current instance.
		/// </summary>
		/// <value>
		///    A <see cref="VBRMethod" /> value containing the VBR
		///    method of the file.
		/// </value>
		public VBRMethod VBRMethod { get; private set; }

		/// <summary>
		///    Gets the LAME VBR method of the file, as indicated by
		///    the current instance.
		/// </summary>
		/// <value>
		///    A <see cref="LameVBRMethod" /> value containing the LAME
		///    VBR method of the file.
		/// </value>
		public LameVBRMethod LameVBRMethod { get; private set; }

		/// <summary>
		///    Gets the lowpass filter value of the file, as indicated
		///    by the current instance.
		/// </summary>
		/// <value>
		///    A <see cref="int" /> value containing the lowpass filter
		///   value of the file.
		/// </value>
		public int LowpassFilter { get; private set; }

		/// <summary>
		///    Gets the replay gain data of the file, as indicated
		///    by the current instance.
		/// </summary>
		/// <value>
		///    A <see cref="LameReplayGainData" /> value containing
		///    the replay gain datavalue of the file.
		/// </value>
		public LameReplayGainData LameReplayGainData { get; private set; }

		/// <summary>
		///    Gets if LAME uses --nspsytune.
		/// </summary>
		/// <value>
		///    A <see cref="bool" /> value indicating if --nspsytune
		///    is used.
		/// </value>
		public bool NSPsytuneUsed { get; private set; }

		/// <summary>
		///    Gets if LAME uses --nssafejoint.
		/// </summary>
		/// <value>
		///    A <see cref="bool" /> value indicating if --nssafejoint
		///    is used.
		/// </value>
		public bool NSSafeJointUsed { get; private set; }

		/// <summary>
		///    Gets if the track is --nogap continued in a next track.
		/// </summary>
		/// <value>
		///    A <see cref="bool" /> indicating if the track is --nogap
		///    continued in a next track.
		/// </value>
		public bool IsNoGapContinued { get; private set; }

		/// <summary>
		///    Gets if the track is the --nogap continuation of an
		///    earlier one.
		/// </summary>
		/// <value>
		///    A <see cref="bool" /> indicating if the track is the
		///    --nogap continuation of an earlier one.
		/// </value>
		public bool IsNoGapContinuation { get; private set; }

		/// <summary>
		///    Gets the ATH type of the file, as indicated by the
		///    current instance.
		/// </summary>
		/// <value>
		///    A <see cref="int" /> value containing ATH type of the
		///    file.
		/// </value>
		public int ATHType { get; private set; }

		/// <summary>
		///    Gets the bitrate value of the file, as indicated by the
		///    current instance.
		/// </summary>
		/// <value>
		///    A <see cref="int" /> value containing the bitrate of the
		///    file.
		/// </value>
		public int BitrateValue { get; private set; }

		/// <summary>
		///    Gets a description of the bitrate value of the file,
		///    as indicated by the current instance.
		/// </summary>
		/// <value>
		///    A <see cref="string" /> value containing a description
		///    of bitrate of the file.
		/// </value>
		public string BitrateValueDescription { get; private set; }

		/// <summary>
		///    Gets the encoder delay of the file, as indicated by the
		///    current instance.
		/// </summary>
		/// <value>
		///    A <see cref="int" /> value containing the encoder delay
		///    of the file.
		/// </value>
		public int EncoderDelay { get; private set; }

		/// <summary>
		///    Gets the encoder padding of the file, as indicated by the
		///    current instance.
		/// </summary>
		/// <value>
		///    A <see cref="int" /> value containing the encoder padding
		///    of the file.
		/// </value>
		public int EncoderPadding { get; private set; }

		/// <summary>
		///    Gets the noise shaping of the file, as indicated by the
		///    current instance.
		/// </summary>
		/// <value>
		///    A <see cref="int" /> value containing the noise shaping
		///    of the file.
		/// </value>
		public int NoiseShaping { get; private set; }

		/// <summary>
		///    Gets the stereo mode of the file, as indicated by the
		///    current instance.
		/// </summary>
		/// <value>
		///    A <see cref="LameStereoMode" /> value containing the
		///    stereo mode of the file.
		/// </value>
		public LameStereoMode LameStereoMode { get; private set; }

		/// <summary>
		///    Gets if unwise settings were used when encoding the
		///    file.
		/// </summary>
		/// <value>
		///    A <see cref="bool" /> value indicating if unwise
		///    settings were used.
		/// </value>
		public bool UnwiseSettingsUsed { get; private set; }

		/// <summary>
		///    Gets the soure sample frequency.
		/// </summary>
		/// <value>
		///    A <see cref="LameSourceSampleFrequency" /> value
		///    containing the soure sample frequency.
		/// </value>
		public LameSourceSampleFrequency LameSourceSampleFrequency { get; private set; }

		/// <summary>
		///    Gets the MP3 gain value.
		/// </summary>
		/// <value>
		///    A <see cref="sbyte" /> value containing the MP3 gain.
		/// </value>
		public sbyte Mp3GainValue { get; private set; }

		/// <summary>
		///    Gets the MP3 gain amplification factor value.
		/// </summary>
		/// <value>
		///    A <see cref="double" /> value containing the MP3
		///    amplification factor.
		/// </value>
		public double Mp3GainAmplificationFactor { get; private set; }

		/// <summary>
		///    Gets the MP3 gain decibel change value.
		/// </summary>
		/// <value>
		///    A <see cref="double" /> value containing the MP3 gain
		///    decibel change.
		/// </value>
		public double Mp3GainDecibelChange { get; private set; }

		/// <summary>
		///    Gets the surround encoding information.
		/// </summary>
		/// <value>
		///    A <see cref="LameSurroundEncodingInfo" /> value
		///    containing the surround encoding information.
		/// </value>
		public LameSurroundEncodingInfo LameSurroundEncodingInfo { get; private set; }

		/// <summary>
		///    Gets the LAME preset mode.
		/// </summary>
		/// <value>
		///    A <see cref="LamePresetMode" /> value containing
		///    the LAME preset mode.
		/// </value>
		public LamePresetMode LamePresetMode { get; private set; }

		/// <summary>
		///    Gets the "music length" (see LAME header
		///    specification for more info).
		/// </summary>
		/// <value>
		///    A <see cref="int" /> value containing the "music
		///    length".
		/// </value>
		public int MusicLength { get; private set; }

		/// <summary>
		///    Gets the music CRC (see LAME header specification
		///    for more info).
		/// </summary>
		/// <value>
		///    A <see cref="ushort" /> value containing the music
		///    CRC.
		/// </value>
		public ushort MusicCRC { get; private set; }

		/// <summary>
		///    Gets the info tag CRC (see LAME header specification
		///    for more info).
		/// </summary>
		/// <value>
		///    A <see cref="ushort" /> value containing the info tag
		///    CRC.
		/// </value>
		public ushort InfoTagCRC { get; private set; }

		#endregion

		#region Public Static Methods

		/// <summary>
		///    Constructs and initializes a new instance of
		///    <see cref="LameHeader" /> if one is found in
		///    <paramref name="file" />. If no header can be found,
		///    <see langword="null" /> will be returned.
		/// </summary>
		/// <param name="file">
		///    A <see cref="TagLib.File" /> object to read the LAME
		///    header from.
		/// </param>
		/// <param name="audioHeaderStartPosition">
		///    A <see cref="long" /> value specifying the start
		///    position of the audio header in <paramref name="file" />.
		/// </param>
		/// <param name="lameHeaderStartPosition">
		///    A <see cref="long" /> value specifying the start
		///    position of the LAME header in <paramref name="file" />.
		/// </param>
		/// <param name="qualityIndicator">
		///    A <see cref="uint" /> value containing the quality
		///    indicator value of the xing header of the file, or
		///    <see langword="null" /> if not specified.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///    <paramref name="file" /> is <see langword="null" />.
		/// </exception>
		public static LameHeader? TryCreateLameHeader(TagLib.File file, long audioHeaderStartPosition, long lameHeaderStartPosition, uint? qualityIndicator)
		{
			if (file == null)
				throw new ArgumentNullException (nameof (file));

			file.Seek (lameHeaderStartPosition);

			ByteVector encoder_version_data = file.ReadBlock (9);
			if (encoder_version_data.Count != 9 ||
				encoder_version_data[0] != 0x4C ||
				encoder_version_data[1] != 0x41 ||
				encoder_version_data[2] != 0x4D ||
				encoder_version_data[3] != 0x45) {
				return null;
			}

			return new LameHeader (file, audioHeaderStartPosition, lameHeaderStartPosition + 9, encoder_version_data.ToString(), qualityIndicator);
		}

		/// <summary>
		///     Calculates the CRC of the music data and returns if
		///     it matches the CRC value in the LAME header.
		/// </summary>
		/// <param name="file">
		///    A <see cref="TagLib.File" /> object to check the music
		///    CRC data of.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///    <paramref name="file" /> is <see langword="null" />.
		/// </exception>
		/// <exception cref="CorruptFileException">
		///    Reading from <paramref name="file" /> failed.
		/// </exception>
		public static bool CheckMusicCRC (TagLib.File file)
		{
			if (file == null)
				throw new ArgumentNullException (nameof (file));

			foreach (ICodec codec in file.Properties.Codecs) {
				if (codec is not AudioHeader) {
					continue;
				}

				var audioHeader = (AudioHeader)codec;

				if (!audioHeader.XingHeader.Present ||
					audioHeader.XingHeader.LameHeader == null) {
					continue;
				}

				LameHeader lameHeader = audioHeader.XingHeader.LameHeader.Value;

				int musicLengthAdjusted = lameHeader.MusicLength - 0xC0;

				file.Mode = TagLib.File.AccessMode.Read;

				file.Seek (lameHeader._audioHeaderStartPosition + 0xC0);
				ByteVector music_data_for_crc = file.ReadBlock (musicLengthAdjusted);

				file.Mode = TagLib.File.AccessMode.Closed;

				if (music_data_for_crc.Count != musicLengthAdjusted) {
					throw new CorruptFileException ("Read failed.");
				}

				return lameHeader.MusicCRC == music_data_for_crc.CRC16;
			}

			throw new ArgumentException ("file does not contain a Lame header", nameof(file));
		}

		/// <summary>
		///     Calculates the CRC of the info tag data and
		///     returns if it matches the CRC value in the
		///     LAME header.
		/// </summary>
		/// <param name="file">
		///    A <see cref="TagLib.File" /> object to check the info
		///    tag CRC data of.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///    <paramref name="file" /> is <see langword="null" />.
		/// </exception>
		/// <exception cref="CorruptFileException">
		///    Reading from <paramref name="file" /> failed.
		/// </exception>
		public static bool CheckInfoTagCRC (TagLib.File file)
		{
			if (file == null)
				throw new ArgumentNullException (nameof (file));

			foreach (ICodec codec in file.Properties.Codecs) {
				if (codec is not AudioHeader) {
					continue;
				}

				var audioHeader = (AudioHeader)codec;

				if (!audioHeader.XingHeader.Present ||
					audioHeader.XingHeader.LameHeader == null) {
					continue;
				}

				LameHeader lameHeader = audioHeader.XingHeader.LameHeader.Value;

				file.Mode = TagLib.File.AccessMode.Read;

				file.Seek (lameHeader._audioHeaderStartPosition);
				ByteVector data_covered_by_info_tag_crc = file.ReadBlock (190);

				file.Mode = TagLib.File.AccessMode.Closed;

				if (data_covered_by_info_tag_crc.Count != 190) {
					throw new CorruptFileException ("Read failed.");
				}

				return lameHeader.InfoTagCRC == data_covered_by_info_tag_crc.CRC16;
			}

			throw new ArgumentException ("file does not contain a Lame header", nameof (file));
		}

		#endregion
	}
}
