// using AElf;
// using AElf.Client;
// using AElf.Client.Dto;
// using AElf.Cryptography;
// using Google.Protobuf;
// using Google.Protobuf.WellKnownTypes;
// using Newtonsoft.Json;
//
//
// namespace GuardianTool.utils;
//
// using AElf.Types;
//
//
// public class Helper
// {
//     // Set this first
//     private static readonly string Env = "aefinder-local";
//     public static List<VerifierInfo> GetVerifierList()
//     {
//         var map = new Dictionary<string, List<VerifierInfo>>();
//
//         map["Test1"] = new List<VerifierInfo>
//         {
//             new()
//             {
//                 Name = "Portkey",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Portkey.png",
//                 EndPoints = "http://192.168.66.240:16010",
//                 Address = "2mBnRTqXMb5Afz4CWM2QakLRVDfaq2doJNRNQT1MXoi2uc6Zy3",
//                 PrivateKey = "0700e2351c07574749605669d35d2f7075c578a7124881b348dccf7f3987e1fc"
//             },
//             new()
//             {
//                 Name = "Minerva",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Minerva.png",
//                 EndPoints = "http://192.168.66.240:16020",
//                 Address = "3sWGDJhu5XDycTWXGa6r4qicYKbUyy6oZyRbRRDKGTiWTXwU4",
//                 PrivateKey = "b7bc6077169c557fb503dcb64d43b70795c892dc374fac1b3ac17938cf996fbb"
//             },
//             new()
//             {
//                 Name = "DokewCapital",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/DokewCapital.png",
//                 EndPoints = "http://192.168.66.240:16030",
//                 Address = "2kqh5HHiL4HoGWqwBqWiTNLBnr8eAQBEJi3cjH1btPovTyGwej",
//                 PrivateKey = "484ada7f9adb0e374821b3ae7f85cc3f181ca21e62cf4228d7ff6d1edba6dce0"
//             },
//             new()
//             {
//                 Name = "Gauss",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Gauss.png",
//                 EndPoints = "http://192.168.66.240:16040",
//                 Address = "5M5sG4v1H9cdB4HKsmGrPyyeoNBAEbj2moMarNidzp7xyVDZ7",
//                 PrivateKey = "1c9abba6e6c787b888e674823f5b72ec67d2a64ba59b33fb33f417cd959ebbe4"
//             },
//             new()
//             {
//                 Name = "CryptoGuardian",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/CryptoGuardian.png",
//                 EndPoints = "http://192.168.66.240:16050",
//                 Address = "2bWwpsN9WSc4iKJPHYL4EZX3nfxVY7XLadecnNMar1GdSb4hJz",
//                 PrivateKey = "09da44778f8db2e602fb484334f37df19e221c84c4582ce5b7770ccfbc3ddbef"
//             }
//         };
//
//         map["Test2"] = new List<VerifierInfo>
//         {
//            new()
//             {
//                 Name = "Portkey",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Portkey.png",
//                 EndPoints = "http://192.168.67.51:16010",
//                 Address = "2mBnRTqXMb5Afz4CWM2QakLRVDfaq2doJNRNQT1MXoi2uc6Zy3",
//                 PrivateKey = "0700e2351c07574749605669d35d2f7075c578a7124881b348dccf7f3987e1fc"
//             },
//             new()
//             {
//                 Name = "Minerva",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Minerva.png",
//                 EndPoints = "http://192.168.67.51:16020",
//                 Address = "3sWGDJhu5XDycTWXGa6r4qicYKbUyy6oZyRbRRDKGTiWTXwU4",
//                 PrivateKey = "b7bc6077169c557fb503dcb64d43b70795c892dc374fac1b3ac17938cf996fbb"
//             },
//             new()
//             {
//                 Name = "DokewCapital",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/DokewCapital.png",
//                 EndPoints = "http://192.168.67.51:16030",
//                 Address = "2kqh5HHiL4HoGWqwBqWiTNLBnr8eAQBEJi3cjH1btPovTyGwej",
//                 PrivateKey = "484ada7f9adb0e374821b3ae7f85cc3f181ca21e62cf4228d7ff6d1edba6dce0"
//             },
//             new()
//             {
//                 Name = "Gauss",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Gauss.png",
//                 EndPoints = "http://192.168.67.51:16040",
//                 Address = "5M5sG4v1H9cdB4HKsmGrPyyeoNBAEbj2moMarNidzp7xyVDZ7",
//                 PrivateKey = "1c9abba6e6c787b888e674823f5b72ec67d2a64ba59b33fb33f417cd959ebbe4"
//             },
//             new()
//             {
//                 Name = "CryptoGuardian",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/CryptoGuardian.png",
//                 EndPoints = "http://192.168.67.51:16050",
//                 Address = "2bWwpsN9WSc4iKJPHYL4EZX3nfxVY7XLadecnNMar1GdSb4hJz",
//                 PrivateKey = "09da44778f8db2e602fb484334f37df19e221c84c4582ce5b7770ccfbc3ddbef"
//             }
//         };
//
//         map["Test3"] = new List<VerifierInfo>
//         {
//             new()
//             {
//                 Name = "Portkey",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Portkey.png",
//                 EndPoints = "http://192.168.66.203:6010",
//                 Address = "2mBnRTqXMb5Afz4CWM2QakLRVDfaq2doJNRNQT1MXoi2uc6Zy3",
//                 PrivateKey = "0700e2351c07574749605669d35d2f7075c578a7124881b348dccf7f3987e1fc"
//             },
//             new()
//             {
//                 Name = "Minerva",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Minerva.png",
//                 EndPoints = "http://192.168.66.203:6020",
//                 Address = "3sWGDJhu5XDycTWXGa6r4qicYKbUyy6oZyRbRRDKGTiWTXwU4",
//                 PrivateKey = "b7bc6077169c557fb503dcb64d43b70795c892dc374fac1b3ac17938cf996fbb"
//             },
//             new()
//             {
//                 Name = "DokewCapital",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/DokewCapital.png",
//                 EndPoints = "http://192.168.66.203:6030",
//                 Address = "2kqh5HHiL4HoGWqwBqWiTNLBnr8eAQBEJi3cjH1btPovTyGwej",
//                 PrivateKey = "484ada7f9adb0e374821b3ae7f85cc3f181ca21e62cf4228d7ff6d1edba6dce0"
//             },
//             new()
//             {
//                 Name = "Gauss",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Gauss.png",
//                 EndPoints = "http://192.168.66.203:6040",
//                 Address = "5M5sG4v1H9cdB4HKsmGrPyyeoNBAEbj2moMarNidzp7xyVDZ7",
//                 PrivateKey = "1c9abba6e6c787b888e674823f5b72ec67d2a64ba59b33fb33f417cd959ebbe4"
//             },
//             new()
//             {
//                 Name = "CryptoGuardian",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/CryptoGuardian.png",
//                 EndPoints = "http://192.168.66.203:6050",
//                 Address = "2bWwpsN9WSc4iKJPHYL4EZX3nfxVY7XLadecnNMar1GdSb4hJz",
//                 PrivateKey = "09da44778f8db2e602fb484334f37df19e221c84c4582ce5b7770ccfbc3ddbef"
//             }
//         };
//         
//         map["Test4"] = new List<VerifierInfo>
//         {
//             new()
//             {
//                 Name = "Portkey",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Portkey.png",
//                 EndPoints = "http://192.168.67.67:6010",
//                 Address = "2nYru96VVAUtSUzH4ra432N1dmMawSBr7edbgXetyt97MxXDsE",
//                 PrivateKey = "7656811e65d82252e8b7521c816f4bcac8fa18283c00c4435d01855dde1036de"
//             },
//             new()
//             {
//                 Name = "Minerva",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Minerva.png",
//                 EndPoints = "http://192.168.67.67:6020",
//                 Address = "2mBnRTqXMb5Afz4CWM2QakLRVDfaq2doJNRNQT1MXoi2uc6Zy3",
//                 PrivateKey = "0700e2351c07574749605669d35d2f7075c578a7124881b348dccf7f3987e1fc"
//             },
//             new()
//             {
//                 Name = "DokewCapital",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/DokewCapital.png",
//                 EndPoints = "http://192.168.67.67:6030",
//                 Address = "FNdpA2q16EScXx4Wvi6aKkXajWcrYy1wnTpdXQcBk2Ksr4S3x",
//                 PrivateKey = "fc06e7a57c24ae3d73f89cbefb6f24d2f9aef10f5f48c9b5dd1dcd8f4a1db9ec"
//             },
//             new()
//             {
//                 Name = "Gauss",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Gauss.png",
//                 EndPoints = "http://192.168.67.67:6040",
//                 Address = "bfQXa4CDihKE4nXDMnhVzs7v9dp3doLNWBmKyWH2t4oQmTvkX",
//                 PrivateKey = "63d9202a64933f064c6ad778f140cc33abb3e7ddfea0bf03eb5b5fc89a21e660"
//             },
//             new()
//             {
//                 Name = "CryptoGuardian",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/CryptoGuardian.png",
//                 EndPoints = "http://192.168.67.67:6050",
//                 Address = "7d5DUvsPUq1Q88HMBTDrVgDsMGnnypd6h6e7YUM5HHTN7znFP",
//                 PrivateKey = "e6e7b38cbc541a72e7596ffdab663204c46c1f0782758bcef6c9668f34fac54e"
//             }
//         };
//         
//         map["Pressure"] = new List<VerifierInfo>
//         {
//             new()
//             {
//                 Name = "Portkey",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Portkey.png",
//                 EndPoints = "http://192.168.67.135:8010",
//                 Address = "17afUGmSDQXtFkMGsKnhiHQ5vZB47kAtPLoHAxFwCrYa4PbP2",
//                 PrivateKey = "fc84b51a88e2cb8797a5bb7e9740c3eda7ffd9f8d73efb2827817b2f7f55cf82"
//             },
//             new()
//             {
//                 Name = "Minerva",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Minerva.png",
//                 EndPoints = "http://192.168.67.135:8020",
//                 Address = "29jKMsRWrP7ioxrEQvXF2TjZ3w3dFbLM8vZzfgjxYAbRBScEUY",
//                 PrivateKey = "04092a1868c5a7aeb4ec8999647d433f2e5bb40e0cefa077741bb1343063da4e"
//             },
//             new()
//             {
//                 Name = "DokewCapital",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/DokewCapital.png",
//                 EndPoints = "http://192.168.67.135:8030",
//                 Address = "GTfPkhWLdbNcZ4XN49jgsER1zpEBaVQCwF92ub2PUk8pbZ4ht",
//                 PrivateKey = "982979a5295b700d0194bff0c42793ca0297891a88f98d9b1da8425354bdfa00"
//             },
//             new()
//             {
//                 Name = "Gauss",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Gauss.png",
//                 EndPoints = "http://192.168.67.135:8040",
//                 Address = "27JYk1u7pGNM7g2cioyVQXvtLnNVrs55BKMm1FqsfbVnKnxfve",
//                 PrivateKey = "7b2a15cbc07ac34f07ec7dd21845120d83be4e851e837d6f5f5915534c39a77d"
//             },
//             new()
//             {
//                 Name = "CryptoGuardian",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/CryptoGuardian.png",
//                 EndPoints = "http://192.168.67.135:8050",
//                 Address = "2B8LtuqfQRtCfP7qgAA5F5BHvofZLgug44LjBLv6Vv46DYVQm8",
//                 PrivateKey = "df20ebc84117a2f9c52208dcb18c2564cbbdb0b6cf10b4f189e305edc2f22e0f"
//             }
//         };
//
//         map["TestNet"] = new List<VerifierInfo>
//         {
//             new()
//             {
//                 Name = "Portkey",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Portkey.png",
//                 EndPoints = "http://172.31.32.207:8050",
//                 Address = "2mBnRTqXMb5Afz4CWM2QakLRVDfaq2doJNRNQT1MXoi2uc6Zy3",
//                 PrivateKey = "0700e2351c07574749605669d35d2f7075c578a7124881b348dccf7f3987e1fc"
//             },
//             new()
//             {
//                 Name = "Minerva",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Minerva.png",
//                 EndPoints = "http://172.31.32.207:8030",
//                 Address = "3sWGDJhu5XDycTWXGa6r4qicYKbUyy6oZyRbRRDKGTiWTXwU4",
//                 PrivateKey = "b7bc6077169c557fb503dcb64d43b70795c892dc374fac1b3ac17938cf996fbb"
//             },
//             new()
//             {
//                 Name = "DokewCapital",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/DokewCapital.png",
//                 EndPoints = "http://172.31.32.207:8020",
//                 Address = "2kqh5HHiL4HoGWqwBqWiTNLBnr8eAQBEJi3cjH1btPovTyGwej",
//                 PrivateKey = "484ada7f9adb0e374821b3ae7f85cc3f181ca21e62cf4228d7ff6d1edba6dce0"
//             },
//             new()
//             {
//                 Name = "Gauss",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Gauss.png",
//                 EndPoints = "http://172.31.32.207:8010",
//                 Address = "5M5sG4v1H9cdB4HKsmGrPyyeoNBAEbj2moMarNidzp7xyVDZ7",
//                 PrivateKey = "1c9abba6e6c787b888e674823f5b72ec67d2a64ba59b33fb33f417cd959ebbe4"
//             },
//             new()
//             {
//                 Name = "CryptoGuardian",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/CryptoGuardian.png",
//                 EndPoints = "http://172.31.32.207:8040",
//                 Address = "2bWwpsN9WSc4iKJPHYL4EZX3nfxVY7XLadecnNMar1GdSb4hJz",
//                 PrivateKey = "09da44778f8db2e602fb484334f37df19e221c84c4582ce5b7770ccfbc3ddbef"
//             }
//         };
//         
//          map["Press2"] = new List<VerifierInfo>
//         {
//             new()
//             {
//                 Name = "Portkey",
//                 ImageUrl = "https://portkey-did.s3.ap-northeast-1.amazonaws.com/img/Portkey.png",
//                 EndPoints = "http://92.168.66.206:8050",
//                 Address = "2B8LtuqfQRtCfP7qgAA5F5BHvofZLgug44LjBLv6Vv46DYVQm8",
//                 PrivateKey = "df20ebc84117a2f9c52208dcb18c2564cbbdb0b6cf10b4f189e305edc2f22e0f"
//             },
//             
//         };
//
//         return map[Env];
//     }
//
//     public static List<ChainInfo> GetChainInfos()
//     {
//         var map = new Dictionary<string, List<ChainInfo>>();
//
//         map["Test1"] = new List<ChainInfo>
//         {
//             new()
//             {
//                 ChainId = "AELF",
//                 BaseUrl = "http://192.168.66.61:8000",
//                 ContractAddress = "2imqjpkCwnvYzfnr61Lp2XQVN2JU17LPkA9AZzmRZzV5LRRWmR",
//                 BingoGameContractAddress = "",
//                 TokenContractAddress = "JRmBduh4nXWi1aXgdUsj5gJrzeZb2LxmrAbf7W99faZSvoAaE",
//                 IsMainChain = true
//             },
//             new()
//             {
//                 ChainId = "tDVV",
//                 BaseUrl = "http://192.168.66.100:8000",
//                 ContractAddress = "UYdd84gLMsVdHrgkr3ogqe1ukhKwen8oj32Ks4J1dg6KH9PYC",
//                 BingoGameContractAddress = "2q7NLAr6eqF4CTsnNeXnBZ9k4XcmiUeM61CLWYaym6WsUmbg1k",
//                 TokenContractAddress = "7RzVGiuVWkvL4VfVHdZfQF2Tri3sgLe9U991bohHFfSRZXuGX",
//                 GenesisContractAddress = "2dtnkWDyJJXeDRcREhKSZHrYdDGMbn3eus5KYpXonfoTygFHZm",
//                 IsMainChain = false
//             }
//         };
//
//         map["Test3"] = new List<ChainInfo>
//         {
//             new()
//             {
//                 ChainId = "AELF",
//                 BaseUrl = "http://192.168.66.3:8000",
//                 ContractAddress = "2UM9eusxdRyCztbmMZadGXzwgwKfFdk8pF4ckw58D769ehaPSR",
//                 BingoGameContractAddress = "",
//                 TokenContractAddress = "JRmBduh4nXWi1aXgdUsj5gJrzeZb2LxmrAbf7W99faZSvoAaE",
//                 IsMainChain = true
//             },
//             new()
//             {
//                 ChainId = "tDVV",
//                 BaseUrl = "http://192.168.66.241:8000",
//                 ContractAddress = "fU9csLqXtnSbcyRJs3fPYLFTz2S9EZowUqkYe4zrJgp1avXK2",
//                 BingoGameContractAddress = "2nkBVPGWcQLv1HLHpjLpwCrUNh7oSbzFbMgFnwUcM6tDXivRBw",
//                 TokenContractAddress = "7RzVGiuVWkvL4VfVHdZfQF2Tri3sgLe9U991bohHFfSRZXuGX",
//                 IsMainChain = false
//             }
//         };
//         
//         map["Test4"] = new List<ChainInfo>
//         {
//             new()
//             {
//                 ChainId = "AELF",
//                 BaseUrl = "http://192.168.67.244:8000",
//                 ContractAddress = "2LUmicHyH4RXrMjG4beDwuDsiWJESyLkgkwPdGTR8kahRzq5XS",
//                 BingoGameContractAddress = "",
//                 TokenContractAddress = "JRmBduh4nXWi1aXgdUsj5gJrzeZb2LxmrAbf7W99faZSvoAaE",
//                 IsMainChain = true
//             },
//             new()
//             {
//                 ChainId = "tDVV",
//                 BaseUrl = "http://192.168.67.21:8000",
//                 ContractAddress = "2j6mjWwNgnX7zygPNT3UNwsizPb6bqa3JWk6PcQ5sd1Gbc37MJ",
//                 BingoGameContractAddress = "",
//                 TokenContractAddress = "7RzVGiuVWkvL4VfVHdZfQF2Tri3sgLe9U991bohHFfSRZXuGX",
//                 InscriptionContractAddress = "GiV1cxQZPqpUsxgsTU6mNQdNKTHaKKwPUTNsEfL7YWdhj5vBx",
//                 IsMainChain = false
//             }
//         };
//
//
//         map["Pressure"] = new List<ChainInfo>
//         {
//             new()
//             {
//                 ChainId = "AELF",
//                 BaseUrl = "http://192.168.67.154:8000",
//                 ContractAddress = "2LUmicHyH4RXrMjG4beDwuDsiWJESyLkgkwPdGTR8kahRzq5XS",
//                 BingoGameContractAddress = "",
//                 TokenContractAddress = "JRmBduh4nXWi1aXgdUsj5gJrzeZb2LxmrAbf7W99faZSvoAaE",
//                 IsMainChain = true
//             },
//             new()
//             {
//                 ChainId = "tDVV",
//                 BaseUrl = "http://192.168.66.64:8000",
//                 ContractAddress = "RXcxgSXuagn8RrvhQAV81Z652EEYSwR6JLnqHYJ5UVpEptW8Y",
//                 BingoGameContractAddress = "2wRDbyVF28VBQoSPgdSEFaL4x7CaXz8TCBujYhgWc9qTMxBE3n",
//                 TokenContractAddress = "7RzVGiuVWkvL4VfVHdZfQF2Tri3sgLe9U991bohHFfSRZXuGX",
//                 IsMainChain = false
//             }
//         };
//
//         map["TestNet"] = new List<ChainInfo>
//         {
//             new()
//             {
//                 ChainId = "AELF",
//                 BaseUrl = "https://aelf-test-node.aelf.io",
//                 ContractAddress = "iupiTuL2cshxB9UNauXNXe9iyCcqka7jCotodcEHGpNXeLzqG",
//                 TokenContractAddress = "JRmBduh4nXWi1aXgdUsj5gJrzeZb2LxmrAbf7W99faZSvoAaE",
//                 BingoGameContractAddress = "",
//                 IsMainChain = true
//             },
//             new()
//             {
//                 ChainId = "tDVW",
//                 BaseUrl = "https://tdvw-test-node.aelf.io",
//                 ContractAddress = "2WzfRW6KZhAfh3gCZ8Akw4wcti69GUNc1F2sXNa2fgjndv59bE",
//                 TokenContractAddress = "ASh2Wt7nSEmYqnGxPPzp4pnVDU4uhj1XW9Se5VeZcX2UDdyjx",
//                 BingoGameContractAddress = "2CrjkQeeWYTnH9zFHmpuMtxv8ZTBDmHi31zzdo9SUNjmpxJ82T",
//                 IsMainChain = false
//             }
//         };
//         map["Press2"] = new List<ChainInfo>
//         {
//             new()
//             {
//                 ChainId = "AELF",
//                 BaseUrl = "http://192.168.66.215:8000",
//                 ContractAddress = "2LUmicHyH4RXrMjG4beDwuDsiWJESyLkgkwPdGTR8kahRzq5XS",
//                 TokenContractAddress = "JRmBduh4nXWi1aXgdUsj5gJrzeZb2LxmrAbf7W99faZSvoAaE",
//                 BingoGameContractAddress = "",
//                 IsMainChain = true
//             },
//             new()
//             {
//                 ChainId = "tDVV",
//                 BaseUrl = "http://192.168.66.110:8000",
//                 ContractAddress = "2wRDbyVF28VBQoSPgdSEFaL4x7CaXz8TCBujYhgWc9qTMxBE3n",
//                 TokenContractAddress = "7RzVGiuVWkvL4VfVHdZfQF2Tri3sgLe9U991bohHFfSRZXuGX",
//                 BingoGameContractAddress = "",
//                 IsMainChain = false
//             }
//         };
//         map["Local"] = new List<ChainInfo>
//         {
//             new()
//             {
//                 ChainId = "AELF",
//                 BaseUrl = "http://localhost:8000",
//                 ContractAddress = "2LUmicHyH4RXrMjG4beDwuDsiWJESyLkgkwPdGTR8kahRzq5XS",
//                 TokenContractAddress = "JRmBduh4nXWi1aXgdUsj5gJrzeZb2LxmrAbf7W99faZSvoAaE",
//                 BingoGameContractAddress = "2LUmicHyH4RXrMjG4beDwuDsiWJESyLkgkwPdGTR8kahRzq5XS",
//                 IsMainChain = true
//             },
//             new()
//             {
//                 ChainId = "AELF",
//                 BaseUrl = "http://localhost:8000",
//                 ContractAddress = "iupiTuL2cshxB9UNauXNXe9iyCcqka7jCotodcEHGpNXeLzqG",
//                 TokenContractAddress = "JRmBduh4nXWi1aXgdUsj5gJrzeZb2LxmrAbf7W99faZSvoAaE",
//                 BingoGameContractAddress = "2LUmicHyH4RXrMjG4beDwuDsiWJESyLkgkwPdGTR8kahRzq5XS",
//                 IsMainChain = true
//             }
//         };
//         
//         map["Main"] = new List<ChainInfo>
//         {
//             new()
//             {
//                 ChainId = "AELF",
//                 BaseUrl = "https://aelf-public-node.aelf.io",
//                 ContractAddress = "28PcLvP41ouUd6UNGsNRvKpkFTe6am34nPy4YPsWUJnZNwUvzM",
//                 TokenContractAddress = "JRmBduh4nXWi1aXgdUsj5gJrzeZb2LxmrAbf7W99faZSvoAaE",
//                 BingoGameContractAddress = "",
//                 IsMainChain = true
//             },
//             new()
//             {
//                 ChainId = "tDVV",
//                 BaseUrl = "https://tdvv-public-node.aelf.io",
//                 ContractAddress = "2cLA9kJW3gdHuGoYNY16Qir69J3Nkn6MSsuYxRkUHbz4SG2hZr",
//                 TokenContractAddress = "7RzVGiuVWkvL4VfVHdZfQF2Tri3sgLe9U991bohHFfSRZXuGX",
//                 BingoGameContractAddress = "",
//                 IsMainChain = true
//             }
//         };
//
//         return map[Env];
//     }
//
//     // public static List<CAServerInfo> GetCAServerInfos()
//     // {
//     //     var map = new Dictionary<string, List<CAServerInfo>>();
//     //
//     //     map["Test1"] = new List<CAServerInfo>
//     //     {
//     //         new()
//     //         {
//     //             Name = "CAServer",
//     //             EndPoint = "http://192.168.66.240"
//     //         }
//     //     };
//     //
//     //     map["Test2"] = new List<CAServerInfo>
//     //     {
//     //         new()
//     //         {
//     //             Name = "CAServer",
//     //             EndPoint = "http://192.168.67.51"
//     //         }
//     //     };
//     //
//     //     map["Pressure"] = new List<CAServerInfo>
//     //     {
//     //         new()
//     //         {
//     //             Name = "portkey-server-1",
//     //             EndPoint = "http://192.168.66.198"
//     //         },
//     //         new()
//     //         {
//     //             Name = "portkey-server-2",
//     //             EndPoint = "http://192.168.66.46"
//     //         }
//     //     };
//     //
//     //     map["TestNet"] = new List<CAServerInfo>
//     //     {
//     //         new()
//     //         {
//     //             Name = "CAServer",
//     //             EndPoint = "http://172.31.32.207"
//     //         }
//     //     };
//     //
//     //     return map[Env];
//     // }
//     
//     
//     
//     public static async Task<SendTransactionOutput> SendTransaction(AElfClient client,string privateKey,string contractAddress,string methodNmae,  IMessage param)
//     {
//        
//         var transaction =await client.GenerateTransactionAsync(client.GetAddressFromPrivateKey(privateKey), contractAddress, methodNmae, param);
//         var txWithSign = client.SignTransaction(privateKey, transaction);
//
//         var transactionResult = await client.SendTransactionAsync(new SendTransactionInput()
//         {
//             RawTransaction = txWithSign.ToByteArray().ToHex()
//         });
//
//         return transactionResult;
//
//     }
//
//     public static async Task<string> ExecuteTransaction(AElfClient client, string privateKey,string contractAddress,string methodNmae,  IMessage param)
//     {
//         
//         var transaction =await client.GenerateTransactionAsync(client.GetAddressFromPrivateKey(privateKey), contractAddress, methodNmae, param);
//         var txWithSign = client.SignTransaction(privateKey, transaction);
//
//         var transactionResult = await client.ExecuteTransactionAsync(new ExecuteTransactionDto()
//         {
//             RawTransaction = txWithSign.ToByteArray().ToHex()
//         });
//
//         return transactionResult;
//
//     }
//     
//     private static async Task<T> CallTransactionAsync<T>(ChainInfo info, IMessage param, string methodName, string address)
//         where T : IMessage<T>, new()
//     {
//         var client = new AElfClient(info.BaseUrl);
//         await client.IsConnectedAsync();
//         var wallet =client.GenerateKeyPairInfo();
//         var ownAddress = client.GetAddressFromPrivateKey(wallet.PrivateKey);
//
//         var transaction =
//             await client.GenerateTransactionAsync(ownAddress, address,
//                 methodName, param);
//         var txWithSign = client.SignTransaction(wallet.PrivateKey, transaction);
//
//         var result = await client.ExecuteTransactionAsync(new ExecuteTransactionDto
//         {
//             RawTransaction = txWithSign.ToByteArray().ToHex()
//         });
//
//         var value = new T();
//         value.MergeFrom(ByteArrayHelper.HexStringToByteArray(result));
//
//         return value;
//     }
//     
//     // public static async Task<GetVerifierServersOutput> GetVerifierAsync(ChainInfo info)
//     // {
//     //     var methodName = "GetVerifierServers";
//     //
//     //     var result =
//     //         await CallTransactionAsync<GetVerifierServersOutput>(info, new Empty(), methodName, info.ContractAddress);
//     //
//     //     Console.WriteLine($"\nGetVerifierServers on chain: {info.ChainId}");
//     //     /*
//     //     foreach (var server in result.VerifierServers)
//     //     {
//     //         Console.WriteLine(
//     //             $"Id: {server.Id.ToHex()}\nName: {server.Name}\nImageUrl: {server.ImageUrl}\nEndPoints: {server.EndPoints}\nAddress: {JsonConvert.SerializeObject(server.VerifierAddresses.Select(a => a.ToBase58()))}");
//     //     }
//     //     */
//     //     return result;
//     // }
//     
//     // public static async Task<GetHolderInfoOutput> GetHolderInfoAsync(ChainInfo info, string? hash, string? log)
//     // {
//     //     var methodName = "GetHolderInfo";
//     //     var param = new GetHolderInfoInput
//     //     {
//     //         CaHash = string.IsNullOrEmpty(hash) ? null : Hash.LoadFromHex(hash),
//     //         LoginGuardianIdentifierHash = string.IsNullOrEmpty(log) ? Hash.Empty : Hash.LoadFromHex(log)
//     //     };
//     //
//     //     var result = await CallTransactionAsync<GetHolderInfoOutput>(info, param, methodName, info.ContractAddress);
//     //
//     //     Console.WriteLine(
//     //         $"GetHolderInfo on chain: {info.ChainId} Result: \n{JsonConvert.SerializeObject(result.ToString())}");
//     //
//     //     return result;
//     // }
//     
//     
//     
//     
//     
//     public static ByteString GenerateSignature(byte[] privateKey, Address verifierAddress,
//         DateTime verificationTime, Hash guardianHash, int type,string salt, int operationType)
//     {
//         //var guardianHash = HashHelper.ComputeFrom(guardian).ToHex();
//         //var guardianHash = guardian;
//         // var data = $"{type},{guardianHash.ToHex()},{verificationTime:yyyy/MM/dd HH:mm:ss.fff},{verifierAddress.ToBase58()},{salt},{operationType}";
//
//         long targetId = 1866392;
//         var data = $"{type},{guardianHash.ToHex()},{verificationTime:yyyy/MM/dd HH:mm:ss.fff},{verifierAddress.ToBase58()},{salt},{operationType},{targetId}";
//
//         var dataHash = HashHelper.ComputeFrom(data);
//         var signature = CryptoHelper.SignWithPrivateKey(privateKey, dataHash.ToByteArray());
//         return ByteStringHelper.FromHexString(signature.ToHex());
//     }
// }
//
// public class ChainInfo
// {
//     public string ChainId { get; set; }
//     public string BaseUrl { get; set; }
//     public string ContractAddress { get; set; }
//     public string TokenContractAddress { get; set; }
//     public string BingoGameContractAddress { get; set; }
//     public string GenesisContractAddress { get; set; }
//     public bool IsMainChain { get; set; }
//     
//     public string InscriptionContractAddress { get; set; }
// }
//
// public class CAServerInfo
// {
//     public string Name { get; set; }
//     public string EndPoint { get; set; }
// }
//
// public class VerifierInfo
// {
//     public string Name { get; set; }
//     public string EndPoints { get; set; }
//     public string ImageUrl { get; set; }
//     public string Address { get; set; }
//     public string PrivateKey { get; set; }
// }
//
