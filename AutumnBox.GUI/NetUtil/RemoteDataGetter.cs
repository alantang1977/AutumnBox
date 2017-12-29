﻿/* =============================================================================*\
*
* Filename: RemoteDataGetter
* Description: 
*
* Version: 1.0
* Created: 2017/10/16 14:08:40(UTC+8:00)
* Compiler: Visual Studio 2017
* 
* Author: zsh2401
* Company: I am free man
*
\* =============================================================================*/
//#define USE_LOCAL_API
using AutumnBox.Support.CstmDebug;
using System;
using System.Net;
using System.Threading.Tasks;
namespace AutumnBox.GUI.NetUtil
{
    [LogProperty(TAG = "Net Unit", Show = false)]
    internal abstract class RemoteDataGetter<TResult>
        where TResult : class
    {
        protected readonly WebClient webClient;
        public RemoteDataGetter()
        {
            webClient = new WebClient();
        }
        public async void RunAsync(Action<TResult> finishedHandler)
        {
            TResult result = await Task.Run(() =>
            {
                return Run();
            });
            if (result != null)
            {
                finishedHandler(result);
            }
        }
        public TResult Run()
        {
            try
            {
#if DEBUG && USE_LOCAL_API
                return LocalMethod();
#else
                return NetMethod();
#endif
            }
            catch (Exception e)
            {
                Logger.T("failed...", e);
                return null;
            }
        }
        public abstract TResult LocalMethod();
        public abstract TResult NetMethod();
    }
}