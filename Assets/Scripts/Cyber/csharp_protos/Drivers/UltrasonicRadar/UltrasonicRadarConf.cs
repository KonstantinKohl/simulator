// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: modules/drivers/radar/ultrasonic_radar/proto/ultrasonic_radar_conf.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Apollo.Drivers.UltrasonicRadar {

  /// <summary>Holder for reflection information generated from modules/drivers/radar/ultrasonic_radar/proto/ultrasonic_radar_conf.proto</summary>
  public static partial class UltrasonicRadarConfReflection {

    #region Descriptor
    /// <summary>File descriptor for modules/drivers/radar/ultrasonic_radar/proto/ultrasonic_radar_conf.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UltrasonicRadarConfReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ckhtb2R1bGVzL2RyaXZlcnMvcmFkYXIvdWx0cmFzb25pY19yYWRhci9wcm90",
            "by91bHRyYXNvbmljX3JhZGFyX2NvbmYucHJvdG8SH2Fwb2xsby5kcml2ZXJz",
            "LnVsdHJhc29uaWNfcmFkYXIaNW1vZHVsZXMvZHJpdmVycy9jYW5idXMvcHJv",
            "dG8vY2FuX2NhcmRfcGFyYW1ldGVyLnByb3RvIqEBCgdDYW5Db25mEkMKEmNh",
            "bl9jYXJkX3BhcmFtZXRlchgBIAEoCzInLmFwb2xsby5kcml2ZXJzLmNhbmJ1",
            "cy5DQU5DYXJkUGFyYW1ldGVyEhkKEWVuYWJsZV9kZWJ1Z19tb2RlGAIgASgI",
            "EhsKE2VuYWJsZV9yZWNlaXZlcl9sb2cYAyABKAgSGQoRZW5hYmxlX3NlbmRl",
            "cl9sb2cYBCABKAgiZwoTVWx0cmFzb25pY1JhZGFyQ29uZhI6CghjYW5fY29u",
            "ZhgBIAEoCzIoLmFwb2xsby5kcml2ZXJzLnVsdHJhc29uaWNfcmFkYXIuQ2Fu",
            "Q29uZhIUCgxlbnRyYW5jZV9udW0YAiABKAViBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Apollo.Drivers.Canbus.CanCardParameterReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Apollo.Drivers.UltrasonicRadar.CanConf), global::Apollo.Drivers.UltrasonicRadar.CanConf.Parser, new[]{ "CanCardParameter", "EnableDebugMode", "EnableReceiverLog", "EnableSenderLog" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Apollo.Drivers.UltrasonicRadar.UltrasonicRadarConf), global::Apollo.Drivers.UltrasonicRadar.UltrasonicRadarConf.Parser, new[]{ "CanConf", "EntranceNum" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class CanConf : pb::IMessage<CanConf> {
    private static readonly pb::MessageParser<CanConf> _parser = new pb::MessageParser<CanConf>(() => new CanConf());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CanConf> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Apollo.Drivers.UltrasonicRadar.UltrasonicRadarConfReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CanConf() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CanConf(CanConf other) : this() {
      CanCardParameter = other.canCardParameter_ != null ? other.CanCardParameter.Clone() : null;
      enableDebugMode_ = other.enableDebugMode_;
      enableReceiverLog_ = other.enableReceiverLog_;
      enableSenderLog_ = other.enableSenderLog_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CanConf Clone() {
      return new CanConf(this);
    }

    /// <summary>Field number for the "can_card_parameter" field.</summary>
    public const int CanCardParameterFieldNumber = 1;
    private global::Apollo.Drivers.Canbus.CANCardParameter canCardParameter_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Apollo.Drivers.Canbus.CANCardParameter CanCardParameter {
      get { return canCardParameter_; }
      set {
        canCardParameter_ = value;
      }
    }

    /// <summary>Field number for the "enable_debug_mode" field.</summary>
    public const int EnableDebugModeFieldNumber = 2;
    private bool enableDebugMode_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool EnableDebugMode {
      get { return enableDebugMode_; }
      set {
        enableDebugMode_ = value;
      }
    }

    /// <summary>Field number for the "enable_receiver_log" field.</summary>
    public const int EnableReceiverLogFieldNumber = 3;
    private bool enableReceiverLog_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool EnableReceiverLog {
      get { return enableReceiverLog_; }
      set {
        enableReceiverLog_ = value;
      }
    }

    /// <summary>Field number for the "enable_sender_log" field.</summary>
    public const int EnableSenderLogFieldNumber = 4;
    private bool enableSenderLog_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool EnableSenderLog {
      get { return enableSenderLog_; }
      set {
        enableSenderLog_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CanConf);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CanConf other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(CanCardParameter, other.CanCardParameter)) return false;
      if (EnableDebugMode != other.EnableDebugMode) return false;
      if (EnableReceiverLog != other.EnableReceiverLog) return false;
      if (EnableSenderLog != other.EnableSenderLog) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (canCardParameter_ != null) hash ^= CanCardParameter.GetHashCode();
      if (EnableDebugMode != false) hash ^= EnableDebugMode.GetHashCode();
      if (EnableReceiverLog != false) hash ^= EnableReceiverLog.GetHashCode();
      if (EnableSenderLog != false) hash ^= EnableSenderLog.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (canCardParameter_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(CanCardParameter);
      }
      if (EnableDebugMode != false) {
        output.WriteRawTag(16);
        output.WriteBool(EnableDebugMode);
      }
      if (EnableReceiverLog != false) {
        output.WriteRawTag(24);
        output.WriteBool(EnableReceiverLog);
      }
      if (EnableSenderLog != false) {
        output.WriteRawTag(32);
        output.WriteBool(EnableSenderLog);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (canCardParameter_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CanCardParameter);
      }
      if (EnableDebugMode != false) {
        size += 1 + 1;
      }
      if (EnableReceiverLog != false) {
        size += 1 + 1;
      }
      if (EnableSenderLog != false) {
        size += 1 + 1;
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CanConf other) {
      if (other == null) {
        return;
      }
      if (other.canCardParameter_ != null) {
        if (canCardParameter_ == null) {
          canCardParameter_ = new global::Apollo.Drivers.Canbus.CANCardParameter();
        }
        CanCardParameter.MergeFrom(other.CanCardParameter);
      }
      if (other.EnableDebugMode != false) {
        EnableDebugMode = other.EnableDebugMode;
      }
      if (other.EnableReceiverLog != false) {
        EnableReceiverLog = other.EnableReceiverLog;
      }
      if (other.EnableSenderLog != false) {
        EnableSenderLog = other.EnableSenderLog;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            if (canCardParameter_ == null) {
              canCardParameter_ = new global::Apollo.Drivers.Canbus.CANCardParameter();
            }
            input.ReadMessage(canCardParameter_);
            break;
          }
          case 16: {
            EnableDebugMode = input.ReadBool();
            break;
          }
          case 24: {
            EnableReceiverLog = input.ReadBool();
            break;
          }
          case 32: {
            EnableSenderLog = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  public sealed partial class UltrasonicRadarConf : pb::IMessage<UltrasonicRadarConf> {
    private static readonly pb::MessageParser<UltrasonicRadarConf> _parser = new pb::MessageParser<UltrasonicRadarConf>(() => new UltrasonicRadarConf());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<UltrasonicRadarConf> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Apollo.Drivers.UltrasonicRadar.UltrasonicRadarConfReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UltrasonicRadarConf() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UltrasonicRadarConf(UltrasonicRadarConf other) : this() {
      CanConf = other.canConf_ != null ? other.CanConf.Clone() : null;
      entranceNum_ = other.entranceNum_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UltrasonicRadarConf Clone() {
      return new UltrasonicRadarConf(this);
    }

    /// <summary>Field number for the "can_conf" field.</summary>
    public const int CanConfFieldNumber = 1;
    private global::Apollo.Drivers.UltrasonicRadar.CanConf canConf_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Apollo.Drivers.UltrasonicRadar.CanConf CanConf {
      get { return canConf_; }
      set {
        canConf_ = value;
      }
    }

    /// <summary>Field number for the "entrance_num" field.</summary>
    public const int EntranceNumFieldNumber = 2;
    private int entranceNum_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int EntranceNum {
      get { return entranceNum_; }
      set {
        entranceNum_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as UltrasonicRadarConf);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(UltrasonicRadarConf other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(CanConf, other.CanConf)) return false;
      if (EntranceNum != other.EntranceNum) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (canConf_ != null) hash ^= CanConf.GetHashCode();
      if (EntranceNum != 0) hash ^= EntranceNum.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (canConf_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(CanConf);
      }
      if (EntranceNum != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(EntranceNum);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (canConf_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CanConf);
      }
      if (EntranceNum != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(EntranceNum);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(UltrasonicRadarConf other) {
      if (other == null) {
        return;
      }
      if (other.canConf_ != null) {
        if (canConf_ == null) {
          canConf_ = new global::Apollo.Drivers.UltrasonicRadar.CanConf();
        }
        CanConf.MergeFrom(other.CanConf);
      }
      if (other.EntranceNum != 0) {
        EntranceNum = other.EntranceNum;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            if (canConf_ == null) {
              canConf_ = new global::Apollo.Drivers.UltrasonicRadar.CanConf();
            }
            input.ReadMessage(canConf_);
            break;
          }
          case 16: {
            EntranceNum = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code