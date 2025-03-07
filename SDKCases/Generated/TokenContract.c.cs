// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: token_contract.proto
// </auto-generated>
// Original file comments:
// *
// MultiToken contract.
#pragma warning disable 0414, 1591
#region Designer generated code

using System.Collections.Generic;
using aelf = global::AElf.CSharp.Core;

namespace AElf.Contracts.MultiToken {

  #region Events
  public partial class ExtraTokenListModified : aelf::IEvent<ExtraTokenListModified>
  {
    public global::System.Collections.Generic.IEnumerable<ExtraTokenListModified> GetIndexed()
    {
      return new List<ExtraTokenListModified>
      {
      };
    }

    public ExtraTokenListModified GetNonIndexed()
    {
      return new ExtraTokenListModified
      {
        SymbolListToPayTxSizeFee = SymbolListToPayTxSizeFee,
      };
    }
  }

  public partial class Transferred : aelf::IEvent<Transferred>
  {
    public global::System.Collections.Generic.IEnumerable<Transferred> GetIndexed()
    {
      return new List<Transferred>
      {
      new Transferred
      {
        From = From
      },
      new Transferred
      {
        To = To
      },
      new Transferred
      {
        Symbol = Symbol
      },
      };
    }

    public Transferred GetNonIndexed()
    {
      return new Transferred
      {
        Amount = Amount,
        Memo = Memo,
      };
    }
  }

  public partial class Approved : aelf::IEvent<Approved>
  {
    public global::System.Collections.Generic.IEnumerable<Approved> GetIndexed()
    {
      return new List<Approved>
      {
      new Approved
      {
        Owner = Owner
      },
      new Approved
      {
        Spender = Spender
      },
      new Approved
      {
        Symbol = Symbol
      },
      };
    }

    public Approved GetNonIndexed()
    {
      return new Approved
      {
        Amount = Amount,
      };
    }
  }

  public partial class UnApproved : aelf::IEvent<UnApproved>
  {
    public global::System.Collections.Generic.IEnumerable<UnApproved> GetIndexed()
    {
      return new List<UnApproved>
      {
      new UnApproved
      {
        Owner = Owner
      },
      new UnApproved
      {
        Spender = Spender
      },
      new UnApproved
      {
        Symbol = Symbol
      },
      };
    }

    public UnApproved GetNonIndexed()
    {
      return new UnApproved
      {
        Amount = Amount,
      };
    }
  }

  public partial class Burned : aelf::IEvent<Burned>
  {
    public global::System.Collections.Generic.IEnumerable<Burned> GetIndexed()
    {
      return new List<Burned>
      {
      new Burned
      {
        Burner = Burner
      },
      new Burned
      {
        Symbol = Symbol
      },
      };
    }

    public Burned GetNonIndexed()
    {
      return new Burned
      {
        Amount = Amount,
      };
    }
  }

  public partial class ChainPrimaryTokenSymbolSet : aelf::IEvent<ChainPrimaryTokenSymbolSet>
  {
    public global::System.Collections.Generic.IEnumerable<ChainPrimaryTokenSymbolSet> GetIndexed()
    {
      return new List<ChainPrimaryTokenSymbolSet>
      {
      };
    }

    public ChainPrimaryTokenSymbolSet GetNonIndexed()
    {
      return new ChainPrimaryTokenSymbolSet
      {
        TokenSymbol = TokenSymbol,
      };
    }
  }

  public partial class CalculateFeeAlgorithmUpdated : aelf::IEvent<CalculateFeeAlgorithmUpdated>
  {
    public global::System.Collections.Generic.IEnumerable<CalculateFeeAlgorithmUpdated> GetIndexed()
    {
      return new List<CalculateFeeAlgorithmUpdated>
      {
      };
    }

    public CalculateFeeAlgorithmUpdated GetNonIndexed()
    {
      return new CalculateFeeAlgorithmUpdated
      {
        AllTypeFeeCoefficients = AllTypeFeeCoefficients,
      };
    }
  }

  public partial class RentalCharged : aelf::IEvent<RentalCharged>
  {
    public global::System.Collections.Generic.IEnumerable<RentalCharged> GetIndexed()
    {
      return new List<RentalCharged>
      {
      };
    }

    public RentalCharged GetNonIndexed()
    {
      return new RentalCharged
      {
        Symbol = Symbol,
        Amount = Amount,
        Payer = Payer,
        Receiver = Receiver,
      };
    }
  }

  public partial class RentalAccountBalanceInsufficient : aelf::IEvent<RentalAccountBalanceInsufficient>
  {
    public global::System.Collections.Generic.IEnumerable<RentalAccountBalanceInsufficient> GetIndexed()
    {
      return new List<RentalAccountBalanceInsufficient>
      {
      };
    }

    public RentalAccountBalanceInsufficient GetNonIndexed()
    {
      return new RentalAccountBalanceInsufficient
      {
        Symbol = Symbol,
        Amount = Amount,
      };
    }
  }

  public partial class TokenCreated : aelf::IEvent<TokenCreated>
  {
    public global::System.Collections.Generic.IEnumerable<TokenCreated> GetIndexed()
    {
      return new List<TokenCreated>
      {
      };
    }

    public TokenCreated GetNonIndexed()
    {
      return new TokenCreated
      {
        Symbol = Symbol,
        TokenName = TokenName,
        TotalSupply = TotalSupply,
        Decimals = Decimals,
        Issuer = Issuer,
        IsBurnable = IsBurnable,
        IssueChainId = IssueChainId,
        ExternalInfo = ExternalInfo,
        Owner = Owner,
      };
    }
  }

  public partial class Issued : aelf::IEvent<Issued>
  {
    public global::System.Collections.Generic.IEnumerable<Issued> GetIndexed()
    {
      return new List<Issued>
      {
      };
    }

    public Issued GetNonIndexed()
    {
      return new Issued
      {
        Symbol = Symbol,
        Amount = Amount,
        Memo = Memo,
        To = To,
      };
    }
  }

  public partial class CrossChainTransferred : aelf::IEvent<CrossChainTransferred>
  {
    public global::System.Collections.Generic.IEnumerable<CrossChainTransferred> GetIndexed()
    {
      return new List<CrossChainTransferred>
      {
      };
    }

    public CrossChainTransferred GetNonIndexed()
    {
      return new CrossChainTransferred
      {
        From = From,
        To = To,
        Symbol = Symbol,
        Amount = Amount,
        Memo = Memo,
        ToChainId = ToChainId,
        IssueChainId = IssueChainId,
      };
    }
  }

  public partial class CrossChainReceived : aelf::IEvent<CrossChainReceived>
  {
    public global::System.Collections.Generic.IEnumerable<CrossChainReceived> GetIndexed()
    {
      return new List<CrossChainReceived>
      {
      };
    }

    public CrossChainReceived GetNonIndexed()
    {
      return new CrossChainReceived
      {
        From = From,
        To = To,
        Symbol = Symbol,
        Amount = Amount,
        Memo = Memo,
        FromChainId = FromChainId,
        IssueChainId = IssueChainId,
        ParentChainHeight = ParentChainHeight,
        TransferTransactionId = TransferTransactionId,
      };
    }
  }

  public partial class TransactionFeeDelegationAdded : aelf::IEvent<TransactionFeeDelegationAdded>
  {
    public global::System.Collections.Generic.IEnumerable<TransactionFeeDelegationAdded> GetIndexed()
    {
      return new List<TransactionFeeDelegationAdded>
      {
      new TransactionFeeDelegationAdded
      {
        Delegator = Delegator
      },
      new TransactionFeeDelegationAdded
      {
        Delegatee = Delegatee
      },
      new TransactionFeeDelegationAdded
      {
        Caller = Caller
      },
      };
    }

    public TransactionFeeDelegationAdded GetNonIndexed()
    {
      return new TransactionFeeDelegationAdded
      {
      };
    }
  }

  public partial class TransactionFeeDelegationCancelled : aelf::IEvent<TransactionFeeDelegationCancelled>
  {
    public global::System.Collections.Generic.IEnumerable<TransactionFeeDelegationCancelled> GetIndexed()
    {
      return new List<TransactionFeeDelegationCancelled>
      {
      new TransactionFeeDelegationCancelled
      {
        Delegator = Delegator
      },
      new TransactionFeeDelegationCancelled
      {
        Delegatee = Delegatee
      },
      new TransactionFeeDelegationCancelled
      {
        Caller = Caller
      },
      };
    }

    public TransactionFeeDelegationCancelled GetNonIndexed()
    {
      return new TransactionFeeDelegationCancelled
      {
      };
    }
  }

  #endregion
}
#endregion

