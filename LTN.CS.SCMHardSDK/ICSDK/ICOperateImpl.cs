// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.SCMHardSDK.ICSDK
// Author:kolio
// Created:2016/10/26 13:43:33
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/10/26 13:43:33
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTN.CS.SCMHardSDK.SDKInterface;
using Common.Logging;

namespace LTN.CS.SCMHardSDK.ICSDK
{
    public class ICOperateImpl : IICOperate
    {
        private readonly static IICOperate Api = new ICOperateImpl();
        public static IICOperate CreateInstance() { return Api; }

        private int _icdev;
        private bool IsFinde;
        private UInt16 _tagType;
        private UInt32 _snr;
        private byte _size;
        private short _a;
        private readonly Byte[] _psd = { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
        private byte[] _buff;
        private readonly ILog log = LogManager.GetLogger("infoAppender");
        private int Num = 0;
        public bool ICInit(int comno = 0)
        {
            //log.Error("读卡器状态：初始化");
            bool rs = false;
            try
            {
                _icdev = ICSDK.rf_init((short)comno, 9600);
                rs = _icdev > 0;
                if (_icdev < 0 || _icdev == 0)
                {
                    log.Error("读卡器状态：初始化错误" + _icdev);
                }
            }
            catch (Exception ex)
            {
                if (_icdev > 0)
                {
                    ICSDK.rf_exit(_icdev);
                    _icdev = 0;
                }
                IsFinde = false;
                log.Error("读卡器状态：初始化异常" + _icdev);
            }
            return rs;
        }

        public string ICRead(int comno)
        {
            _tagType = 0;
            _snr = 0;
            _size = 0;
            string rs = string.Empty;
            try
            {
                if (!IsFinde)
                {
                    if (_icdev > 0)
                    {
                        ICSDK.rf_exit(_icdev);
                        _icdev = 0;
                    }
                    bool rsTemp = ICInit(comno);
                    IsFinde = rsTemp;
                    //log.Error("读卡器状态：初始化");
                }
                if (_icdev > 0)
                {
                    //log.Error("读卡器状态：寻卡开始");
                    _a = ICSDK.rf_request(_icdev, 0, out _tagType);//寻卡请求
                    if (_a != 0)
                    {
                        if (Num > 200)
                        {
                            Num = 0;
                            ICExit();
                        }
                        Num++;
                        return string.Empty;
                    }
                    log.Error("读卡器状态：寻卡");
                    _a = ICSDK.rf_anticoll(_icdev, 0, out _snr);//卡防冲突，返回卡的序列号
                    if (_a != 0)
                    {
                        ICExit();
                        return string.Empty;
                    } 
                    _a = ICSDK.rf_select(_icdev, _snr, out _size);//从多个卡中选取一个给定序列号的卡 
                    if (_a != 0)
                    {
                        ICExit();
                        return string.Empty;
                    } 
                    _a = ICSDK.rf_load_key(_icdev, 0, 0, _psd);//将密码装入读写模块RAM中
                    if (_a != 0)
                    {
                        ICExit();
                        return string.Empty;
                    } 
                    _a = ICSDK.rf_authentication(_icdev, 0, 0);//验证某一扇区密码
                    if (_a != 0)
                    {
                        ICExit();
                        return string.Empty;
                    } 
                    log.Error("读卡器状态：验证");
                    _buff = new byte[16];
                    _a = ICSDK.rf_read(_icdev, 0, _buff);
                    if (_a != 0)
                    {
                        ICExit();
                        return string.Empty;
                    } 
                    log.Error("读卡器状态：读卡");
                    if (_buff == null || _buff.Length == 0 || BitConverter.ToInt32(_buff, 0) == 0)
                    {
                        ICSDK.rf_exit(_icdev);
                        IsFinde = false;
                        rs = string.Empty;
                    }
                    else
                    {
                        rs = _buff.Aggregate<byte, string>(null, (current, t) => current + (Convert.ToString(t, 16).Length == 1 ? ("0" + Convert.ToString(t, 16)) : Convert.ToString(t, 16)));
                    }
                }
                else
                {
                    rs = string.Empty;
                }
                if (_icdev > 0)
                {
                    if (rs != string.Empty)
                    {
                        ICBeep(10);
                    }
                    ICSDK.rf_exit(_icdev);
                    _icdev = 0;
                }
                IsFinde = false;
            }
            catch (Exception ex)
            {
                log.Error("读卡器状态：" + ex.Message);
                if (_icdev > 0)
                {
                    ICSDK.rf_exit(_icdev);
                    _icdev = 0;
                }
                IsFinde = false;
                rs = string.Empty;
            }
            return rs;
        }
        public void ICExit()
        {
            try
            {
                if (_icdev > 0)
                {
                    ICSDK.rf_exit(_icdev);
                    _icdev = 0;
                    IsFinde = false;
                }
            }
            catch (Exception ex)
            {
                IsFinde = false;
            }
        }
        public void ICBeep(int time)
        {
            try
            {
                ICSDK.rf_beep(_icdev, time);
            }
            catch (Exception ex)
            {
                if (_icdev > 0)
                {
                    ICSDK.rf_exit(_icdev);
                    _icdev = 0;
                }
                IsFinde = false;
            }
        }
    }
}
