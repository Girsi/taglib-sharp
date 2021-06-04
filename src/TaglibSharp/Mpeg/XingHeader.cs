//
// XingHeader.cs: Provides information about a variable bitrate MPEG audio
// stream.
//
// Author:
//   Brian Nickel (brian.nickel@gmail.com)
//
// Original Source:
//   xingheader.cpp from TagLib
//
// Copyright (C) 2005-2007 Brian Nickel
// Copyright (C) 2003 by Ismael Orenstein (Original Implementation)
// 
// This library is free software; you can redistribute it and/or modify
// it  under the terms of the GNU Lesser General Public License version
// 2.1 as published by the Free Software Foundation.
//
// This library is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307
// USA
//

using System;

namespace TagLib.Mpeg
{
	/// <summary>
	///    This structure provides information about a variable bitrate MPEG
	///    audio stream.
	/// </summary>
	public struct XingHeader
	{
		#region Enums

		/// <summary>
		///    Indicates the VBR header ID of a <see cref="XingHeader" />.
		/// </summary>
		public enum VBRHeaderID
		{
			/// <summary>
			///    Xing
			/// </summary>
			Xing,
			/// <summary>
			///    Info
			/// </summary>
			Info
		}

		#endregion

		#region Private Fields

		/// <summary>
		///    Contains the Xing identifier.
		/// </summary>
		/// <value>
		///    "Xing"
		/// </value>
		private static readonly ReadOnlyByteVector XingHeaderIdentifier = "Xing";

		/// <summary>
		///    Contains the Info identifier.
		/// </summary>
		/// <value>
		///    "Info"
		/// </value>
		private static readonly ReadOnlyByteVector InfoHeaderIdentifier = "Info";

		#endregion

		#region Public Fields

		/// <summary>
		///    An empty and unset Xing header.
		/// </summary>
		public static readonly XingHeader Unknown = new XingHeader (0, 0);

		#endregion

		#region Constructors

		/// <summary>
		///    Constructs and initializes a new instance of <see
		///    cref="XingHeader" /> with a specified frame count and
		///    size.
		/// </summary>
		/// <param name="frame">
		///    A <see cref="uint" /> value specifying the frame count of
		///    the audio represented by the new instance.
		/// </param>
		/// <param name="size">
		///    A <see cref="uint" /> value specifying the stream size of
		///    the audio represented by the new instance.
		/// </param>
		private XingHeader (uint frame, uint size)
		{
			HeaderID = VBRHeaderID.Xing;
			TotalFrames = frame;
			TotalSize = size;
			Present = false;
			TOCEntries = null;
			QualityIndicator = null;
			LameHeader = null;
		}

		/// <summary>
		///    Constructs and initializes a new instance of <see
		///    cref="XingHeader" /> by reading its raw contents.
		/// </summary>
		/// <param name="file">
		///    A <see cref="TagLib.File" /> object to read the Xing
		///    header from.
		/// </param>
		/// <param name="audioHeaderStartPosition">
		///    A <see cref="long" /> value specifying the start
		///    position of the audio header in <paramref name="file" />.
		/// </param>
		/// <param name="xingHeaderFlagsOffset">
		///    A <see cref="long" /> value specifying the offset
		///    of the XING header flags from
		///    <paramref name="audioHeaderStartPosition" /> in
		///    <paramref name="file" />.
		/// </param>
		/// <param name="headerId">
		///    A <see cref="VBRHeaderID" /> value indicating the VBR
		///    header ID of the file.
		/// </param>
		/// <exception cref="CorruptFileException">
		///    Parsing <paramref name="file" /> failed.
		/// </exception>
		private XingHeader (TagLib.File file, long audioHeaderStartPosition, long xingHeaderFlagsOffset, VBRHeaderID headerId)
		{
			HeaderID = headerId;

			long position = audioHeaderStartPosition + xingHeaderFlagsOffset;
			file.Seek (position);

			ByteVector flags_data = file.ReadBlock (4);
			if (flags_data.Count != 4) {
				throw new CorruptFileException ("Could not read Xing header flags.");
			}

			position += 4;
			file.Seek (position);

			if ((flags_data[3] & 0x01) != 0) {
				ByteVector frames_data = file.ReadBlock (4);
				if (frames_data.Count != 4) {
					throw new CorruptFileException ("Could not read Xing frames field.");
				}

				TotalFrames = frames_data.ToUInt ();

				position += 4;
				file.Seek (position);
			} else
				TotalFrames = 0;

			if ((flags_data[3] & 0x02) != 0) {
				ByteVector bytes_data = file.ReadBlock (4);
				if (bytes_data.Count != 4) {
					throw new CorruptFileException ("Could not read Xing bytes field.");
				}

				TotalSize = bytes_data.ToUInt ();

				position += 4;
				file.Seek (position);
			} else
				TotalSize = 0;

			if ((flags_data[3] & 0x04) != 0) {
				ByteVector toc_data = file.ReadBlock (100);
				if (toc_data.Count != 100) {
					throw new CorruptFileException ("Could not read Xing TOC field.");
				}

				TOCEntries = toc_data;

				position += 100;
				file.Seek (position);
			} else
				TOCEntries = null;

			if ((flags_data[3] & 0x08) != 0) {
				ByteVector quality_indicator_data = file.ReadBlock (4);
				if (quality_indicator_data.Count != 4) {
					throw new CorruptFileException ("Could not read Xing quality indicator field.");
				}

				QualityIndicator = quality_indicator_data.ToUInt ();
				position += 4;
			} else
				QualityIndicator = null;

			LameHeader = Mpeg.LameHeader.TryCreateLameHeader (file, audioHeaderStartPosition, position, QualityIndicator);

			Present = true;
		}

		#endregion

		#region Public Properties

		/// <summary>
		///    Gets the VBR Header ID of the file, as indicated by the
		///    current instance.
		/// </summary>
		/// <value>
		///    A <see cref="VBRHeaderID" /> value indicating the VBR
		///    header ID of the file.
		/// </value>
		public VBRHeaderID HeaderID { get; private set; }

		/// <summary>
		///    Gets the total number of frames in the file, as indicated
		///    by the current instance.
		/// </summary>
		/// <value>
		///    A <see cref="uint" /> value containing the number of
		///    frames in the file, or <c>0</c> if not specified.
		/// </value>
		public uint TotalFrames { get; private set; }

		/// <summary>
		///    Gets the total size of the file, as indicated by the
		///    current instance.
		/// </summary>
		/// <value>
		///    A <see cref="uint" /> value containing the total size of
		///    the file, or <c>0</c> if not specified.
		/// </value>
		public uint TotalSize { get; private set; }

		/// <summary>
		///    Gets the TOC entries of the file, as indicated by the
		///    current instance.
		/// </summary>
		/// <value>
		///    A <see cref="ByteVector" /> value containing the TOC
		///    entries of the file, <see langword="null" /> if not
		///    specified.
		/// </value>
		public ByteVector TOCEntries { get; private set; }

		/// <summary>
		///    Gets the quality indicator of the file, as indicated
		///    by the current instance.
		/// </summary>
		/// <value>
		///    A <see cref="uint" /> value containing the quality
		///    indicator of the file, or <see langword="null" />
		///    if not specified.
		/// </value>
		public uint? QualityIndicator { get; private set; }

		/// <summary>
		///    Gets the LAME header found in the audio represented by
		///    the current instance.
		/// </summary>
		/// <value>
		///    A <see cref="LameHeader" /> object containing the Xing
		///    header found in the audio represented by the current
		///    instance, or <see langword="null" /> if no header was
		///    found.
		/// </value>
		public LameHeader? LameHeader { get; private set; }

		/// <summary>
		///    Gets whether or not a physical Xing header is present in
		///    the file.
		/// </summary>
		/// <value>
		///    A <see cref="bool" /> value indicating whether or not the
		///    current instance represents a physical Xing header.
		/// </value>
		public bool Present { get; private set; }

		#endregion

		#region Private Static Methods

		/// <summary>
		///    Gets the offset at which a Xing header would appear in an
		///    MPEG audio packet based on the version and channel mode.
		/// </summary>
		/// <param name="version">
		///    A <see cref="Version" /> value specifying the version of
		///    the MPEG audio packet.
		/// </param>
		/// <param name="channelMode">
		///    A <see cref="ChannelMode" /> value specifying the channel
		///    mode of the MPEG audio packet.
		/// </param>
		/// <returns>
		///    A <see cref="int" /> value indicating the offset in an
		///    MPEG audio packet at which the Xing header would appear.
		/// </returns>
		private static int XingHeaderOffset (Version version, ChannelMode channelMode)
		{
			bool single_channel = channelMode == ChannelMode.SingleChannel;

			if (version == Version.Version1)
				return single_channel ? 0x15 : 0x24;
			else
				return single_channel ? 0x0D : 0x15;
		}

		#endregion

		#region Public Static Methods

		/// <summary>
		///    Tries to find a Xing header in <paramref name="file" />.
		///    If one is found a new instance of
		///    <see cref="XingHeader" /> is constructed. If no header
		///    can be found, a <see cref="XingHeader.Unknown" /> will be
		///    returned.
		/// <param name="file">
		///    A <see cref="TagLib.File" /> object to read the Xing
		///    header from.
		/// </param>
		/// <param name="audioHeaderStartPosition">
		///    A <see cref="long" /> value specifying the start
		///    position of the audio header in <paramref name="file" />.
		/// </param>
		/// <param name="version">
		///    A <see cref="Version" /> value indicating the MPEG
		///    version used to encode the audio in
		///    <paramref name="file" />.
		/// </param>
		/// <param name="channelMode">
		///    A <see cref="ChannelMode" /> value indicating the MPEG
		///    audio channel mode of the audio in
		///    <paramref name="file" />.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///    <paramref name="file" /> is <see langword="null" />.
		/// </exception>
		/// </summary>
		public static XingHeader TryParseXingHeader (TagLib.File file, long audioHeaderStartPosition, Version version, ChannelMode channelMode)
		{
			if (file == null)
				throw new ArgumentNullException (nameof (file));

			long xingHeaderOffset = XingHeaderOffset (version, channelMode);
			file.Seek (audioHeaderStartPosition + xingHeaderOffset);

			ByteVector vbr_header_id = file.ReadBlock (4);
			if (vbr_header_id.Count != 4) {
				return Unknown;
			}

			VBRHeaderID headerId;

			if (vbr_header_id == XingHeaderIdentifier) {
				headerId = VBRHeaderID.Xing;
			} else if (vbr_header_id == InfoHeaderIdentifier) {
				headerId = VBRHeaderID.Info;
			} else {
				return Unknown;
			}

			return new XingHeader (file, audioHeaderStartPosition, xingHeaderOffset + 4, headerId);
		}

		#endregion
	}
}
