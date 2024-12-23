// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: aelf_test_contract.proto
// </auto-generated>
// Original file comments:
// the version of the language, use proto3 for contracts
#pragma warning disable 0414, 1591
#region Designer generated code

using System.Collections.Generic;
using aelf = global::AElf.CSharp.Core;

namespace AElfTest.Contract {

  #region Events
  public partial class TestTransferred : aelf::IEvent<TestTransferred>
  {
    public global::System.Collections.Generic.IEnumerable<TestTransferred> GetIndexed()
    {
      return new List<TestTransferred>
      {
      new TestTransferred
      {
        From = From
      },
      new TestTransferred
      {
        To = To
      },
      new TestTransferred
      {
        Symbol = Symbol
      },
      };
    }

    public TestTransferred GetNonIndexed()
    {
      return new TestTransferred
      {
        Amount = Amount,
        Memo = Memo,
      };
    }
  }

  public partial class TestTokenCreated : aelf::IEvent<TestTokenCreated>
  {
    public global::System.Collections.Generic.IEnumerable<TestTokenCreated> GetIndexed()
    {
      return new List<TestTokenCreated>
      {
      };
    }

    public TestTokenCreated GetNonIndexed()
    {
      return new TestTokenCreated
      {
        Symbol = Symbol,
        TotalSupply = TotalSupply,
      };
    }
  }

  public partial class AccountAdded : aelf::IEvent<AccountAdded>
  {
    public global::System.Collections.Generic.IEnumerable<AccountAdded> GetIndexed()
    {
      return new List<AccountAdded>
      {
      };
    }

    public AccountAdded GetNonIndexed()
    {
      return new AccountAdded
      {
        Account = Account,
      };
    }
  }

  public partial class AccountRemoved : aelf::IEvent<AccountRemoved>
  {
    public global::System.Collections.Generic.IEnumerable<AccountRemoved> GetIndexed()
    {
      return new List<AccountRemoved>
      {
      };
    }

    public AccountRemoved GetNonIndexed()
    {
      return new AccountRemoved
      {
        Account = Account,
      };
    }
  }

  #endregion
  /// <summary>
  /// the contract definition: a gRPC service definition.
  /// </summary>
  public static partial class AElfTestContractContainer
  {
    static readonly string __ServiceName = "AElfTestContract";

    #region Marshallers
    static readonly aelf::Marshaller<global::AElf.Types.Transaction> __Marshaller_aelf_Transaction = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Types.Transaction.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Standards.ACS2.ResourceInfo> __Marshaller_acs2_ResourceInfo = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Standards.ACS2.ResourceInfo.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElfTest.Contract.InitializeInput> __Marshaller_InitializeInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElfTest.Contract.InitializeInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElfTest.Contract.TestCreateInput> __Marshaller_TestCreateInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElfTest.Contract.TestCreateInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElfTest.Contract.TestTransferInput> __Marshaller_TestTransferInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElfTest.Contract.TestTransferInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Types.Address> __Marshaller_aelf_Address = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Types.Address.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElfTest.Contract.GetTestTokenInfoInput> __Marshaller_GetTestTokenInfoInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElfTest.Contract.GetTestTokenInfoInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElfTest.Contract.TestTokenInfo> __Marshaller_TestTokenInfo = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElfTest.Contract.TestTokenInfo.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElfTest.Contract.GetTestBalanceInput> __Marshaller_GetTestBalanceInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElfTest.Contract.GetTestBalanceInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElfTest.Contract.TestBalance> __Marshaller_TestBalance = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElfTest.Contract.TestBalance.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElfTest.Contract.AccountList> __Marshaller_AccountList = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElfTest.Contract.AccountList.Parser.ParseFrom);
    #endregion

    #region Methods
    static readonly aelf::Method<global::AElf.Types.Transaction, global::AElf.Standards.ACS2.ResourceInfo> __Method_GetResourceInfo = new aelf::Method<global::AElf.Types.Transaction, global::AElf.Standards.ACS2.ResourceInfo>(
        aelf::MethodType.View,
        __ServiceName,
        "GetResourceInfo",
        __Marshaller_aelf_Transaction,
        __Marshaller_acs2_ResourceInfo);

    static readonly aelf::Method<global::AElfTest.Contract.InitializeInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Initialize = new aelf::Method<global::AElfTest.Contract.InitializeInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "Initialize",
        __Marshaller_InitializeInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElfTest.Contract.TestCreateInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_TestCreate = new aelf::Method<global::AElfTest.Contract.TestCreateInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "TestCreate",
        __Marshaller_TestCreateInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElfTest.Contract.TestTransferInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_TestTransfer = new aelf::Method<global::AElfTest.Contract.TestTransferInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "TestTransfer",
        __Marshaller_TestTransferInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElfTest.Contract.TestTransferInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_TransferWithoutParallel = new aelf::Method<global::AElfTest.Contract.TestTransferInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "TransferWithoutParallel",
        __Marshaller_TestTransferInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AddAccount = new aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "AddAccount",
        __Marshaller_aelf_Address,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.Empty> __Method_RemoveAccount = new aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "RemoveAccount",
        __Marshaller_aelf_Address,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElfTest.Contract.GetTestTokenInfoInput, global::AElfTest.Contract.TestTokenInfo> __Method_GetTestTokenInfo = new aelf::Method<global::AElfTest.Contract.GetTestTokenInfoInput, global::AElfTest.Contract.TestTokenInfo>(
        aelf::MethodType.View,
        __ServiceName,
        "GetTestTokenInfo",
        __Marshaller_GetTestTokenInfoInput,
        __Marshaller_TestTokenInfo);

    static readonly aelf::Method<global::AElfTest.Contract.GetTestBalanceInput, global::AElfTest.Contract.TestBalance> __Method_GetTestBalance = new aelf::Method<global::AElfTest.Contract.GetTestBalanceInput, global::AElfTest.Contract.TestBalance>(
        aelf::MethodType.View,
        __ServiceName,
        "GetTestBalance",
        __Marshaller_GetTestBalanceInput,
        __Marshaller_TestBalance);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::AElfTest.Contract.AccountList> __Method_GetAccountList = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::AElfTest.Contract.AccountList>(
        aelf::MethodType.View,
        __ServiceName,
        "GetAccountList",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_AccountList);

    #endregion

    #region Descriptors
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::AElfTest.Contract.AelfTestContractReflection.Descriptor.Services[0]; }
    }

    public static global::System.Collections.Generic.IReadOnlyList<global::Google.Protobuf.Reflection.ServiceDescriptor> Descriptors
    {
      get
      {
        return new global::System.Collections.Generic.List<global::Google.Protobuf.Reflection.ServiceDescriptor>()
        {
          global::AElf.Standards.ACS12.Acs12Reflection.Descriptor.Services[0],
          global::AElf.Standards.ACS2.Acs2Reflection.Descriptor.Services[0],
          global::AElfTest.Contract.AelfTestContractReflection.Descriptor.Services[0],
        };
      }
    }
    #endregion

  }
}
#endregion

