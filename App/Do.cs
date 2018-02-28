using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Security;

using Camouflage.Common;
using Camouflage.Common.ThreadManager;
using System.Net;

namespace YizhiboZan.App
{
    public class Do : IDo
    {
        public int Priority { get; set; } = 1;
        public object Data { get; set; }
        public ThreadManager threadManager { get; set; }

        public EventHandler EndEventHandler { get; set; }

        private string url = "";

        private int count = 0;

        public Do(string url, int c)
        {
            this.url = url;
            count = c;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Start()
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            //hrow new NotImplementedException();
            var HttpItem = new HttpItem()
            {
                Allowautoredirect = true,
                Accept = "text/html,application/xhtml + xml,application/xml;q=0.9,*/*;q=0.8",
                UserAgent = UserAgentList[UserAgentRandom.Next(0, UserAgentList.Count - 1)],
                URL = url
            };

            HttpHelper httpHelper = new HttpHelper();
            httpHelper.GetHtml(HttpItem);

            stopWatch.Stop();
            if (EndEventHandler != null)
            {
                EndEventHandler.Invoke($"({count})执行成功--{stopWatch.ElapsedMilliseconds}--{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}--" + this.url, null);
            }
        }

        public static Random UserAgentRandom = new Random();

        public static List<string> UserAgentList = new List<string>()
        {
            "Mozilla/5.0 (Linux; U; Android 7.0; zh-CN; SM-G9550 Build/NRD90M) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; Android 5.1; m3 note Build/LMY47I; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/48.0.2564.116 Mobile Safari/537.36 T7/9.3 baiduboxapp/9.3.0.10 (Baidu; P1 5.1)",
            "Mozilla/5.0 (Linux; Android 5.1; m2 note Build/LMY47I; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/48.0.2564.116 Mobile Safari/537.36 T7/9.3 baiduboxapp/9.3.0.10 (Baidu; P1 5.1)",
            "Mozilla/5.0 (Linux; Android 5.1; m1 note Build/LMY47I; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/48.0.2564.116 Mobile Safari/537.36 T7/9.3 baiduboxapp/9.3.0.10 (Baidu; P1 5.1)",
            "Mozilla/5.0 (Linux; Android 5.1; m4 note Build/LMY47I; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/48.0.2564.116 Mobile Safari/537.36 T7/9.3 baiduboxapp/9.3.0.10 (Baidu; P1 5.1)",
            "Mozilla/5.0 (Linux; Android 5.1; m5 note Build/LMY47I; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/48.0.2564.116 Mobile Safari/537.36 T7/9.3 baiduboxapp/9.3.0.10 (Baidu; P1 5.1)",
            "Mozilla/5.0 (Linux; U; Android 5.1.1; zh-cn; MI 4S Build/LMY47V) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/53.0.2785.146 Mobile Safari/537.36 XiaoMi/MiuiBrowser/9.1.3",
            "Mozilla/5.0 (iPhone; CPU iPhone OS 10_2 like Mac OS X) AppleWebKit/602.3.12 (KHTML, like Gecko) Mobile/14C92 MicroMessenger/6.5.16 NetType/WIFI Language/zh_CN",
            "Mozilla/5.0 (Linux; U; Android 7.0; zh-CN; ZUK Z2121 Build/NRD90M) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.6.8.952 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; Android 5.1.1; vivo Xplay5A Build/LMY47V; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/48.0.2564.116 Mobile Safari/537.36 T7/9.3 baiduboxapp/9.3.0.10 (Baidu; P1 5.1.1)",
            "Mozilla/5.0 (Linux; Android 7.0; STF-AL10 Build/HUAWEISTF-AL10; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/53.0.2785.49 Mobile MQQBrowser/6.2 TBS/043508 Safari/537.36 V1_AND_SQ_7.2.0_730_YYB_D QQ/7.2.0.3270 NetType/4G WebP/0.3.0 Pixel/1080",
            "Mozilla/5.0 (Linux; Android 6.0; HUAWEI VIE-AL10 Build/HUAWEIVIE-AL10) AppleWebKit/537.36(KHTML,like Gecko) Version/4.0 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 4.4.4; zh-cn; MI 4LTE Build/KTU84P) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/39.0.0.0 Mobile Safari/537.36 XiaoMi/MiuiBrowser/2.1.1",
            "Mozilla/5.0 (Linux; U; Android 4.1.1; zh-cn; SCH-N719 Build/JRO03C) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30",
            "Mozilla/5.0 (Linux; U; Android 4.2.1; zh-cn; 2013022 Build/HM2013022) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Mobile Safari/537.36 XiaoMi/MiuiBrowser/2.1.1",
            "Mozilla/5.0 (Linux; Android 4.1.1; Nexus 7 Build/JRO03D) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.166 Safari/535.19",
            "Mozilla/5.0 (Linux; U; Android 4.4.4; zh-cn; HM NOTE 1LTETD Build/KTU84P) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Mobile Safari/537.36 XiaoMi/MiuiBrowser/2.0.1",
            "Mozilla/5.0 (iPad; CPU OS 8_0_2 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) Version/8.0 Mobile/12A405 Safari/600.1.4",
            "Mozilla/5.0 (Linux; U; Android 7.0; zh-CN; SM-G9550 Build/NRD90M) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 7.0; zh-CN; PRA-AL00 Build/HONORPRA-AL00) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 6.0; zh-CN; HUAWEI VNS-TL00 Build/HUAWEIVNS-TL00) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.2.5.884 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 7.0; zh-CN; ZUK Z2121 Build/NRD90M) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.6.2.948 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 6.0.1; zh-CN; C106 Build/ZAXCNFN5902606201S) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 7.0; zh-CN; ZUK Z2121 Build/NRD90M) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.6.8.952 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 6.0.1; zh-CN; SM-C7000 Build/MMB29M) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.6.2.948 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 4.1.1; zh-cn; M031 Build/JRO03H) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30",
            "Mozilla/5.0 (Linux; U; Android 7.0; zh-CN; MI 5s Build/NRD90M) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 5.1.1; zh-CN; Redmi 3 Build/LMY47V) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 7.1.1; zh-CN; OPPO R11 Build/NMF26X) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 4.2.1; zh-cn; M040 Build/JOP40D) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30",
            "Mozilla/5.0 (Linux; U; Android 6.0.1; zh-CN; KIW-TL00H Build/HONORKIW-TL00H) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 7.0; zh-CN; EVA-DL00 Build/HUAWEIEVA-DL00) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (Windows NT 6.3; Win64; x64; Trident/7.0; Touch; rv:11.0) like Gecko",
            "Mozilla/5.0 (Linux; U; Android 4.4.4; zh-CN; N5209 Build/KTU84P) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 7.0; zh-CN; PRA-AL00X Build/HONORPRA-AL00X) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 7.0; zh-CN; VIE-AL10 Build/HUAWEIVIE-AL10) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 6.0; zh-CN; Redmi Note 4 Build/MRA58K) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 6.0.1; zh-CN; PRO 6 Plus Build/MMB29T) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (iPhone; CPU iPhone OS 7_0_4 like Mac OS X) AppleWebKit/537.51.1 (KHTML, like Gecko) Version/7.0 Mobile/11B554a Safari/9537.53",
            "Mozilla/5.0 (Linux; U; Android 7.1.1; zh-CN; OD105 Build/NMF26F) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.7.0.953 Mobile Safari/537.36",
            "Mozilla/5.0 (Linux; U; Android 4.1.1; zh-cn; M040 Build/JRO03H) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30",
            "Mozilla/5.0 (Linux; U; Android 3.2; zh-cn; GT-P6200 Build/HTJ85B) AppleWebKit/534.13 (KHTML, like Gecko) Version/4.0 Safari/534.13",
            "Mozilla/5.0 (Linux; U; Android 4.0.3; zh-cn; M9 Build/IML74K) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30",
            "Mozilla/5.0 (Linux; U; Android 4.0.4; zh-cn; HTC S720e Build/IMM76D) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30",
            "Mozilla/5.0 (Linux; U; Android 2.3.5; zh-cn; U8800 Build/HuaweiU8800) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1",
            "Mozilla/5.0 (iPad; CPU OS 7_1 like Mac OS X) AppleWebKit/537.51.2 (KHTML, like Gecko) Version/7.0 Mobile/11D167 Safari/9537.53",
            "Mozilla/5.0 (Linux; U; Android 4.4.4; zh-cn; M351 Build/KTU84P) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30",
            "Mozilla/5.0 (iPhone; CPU iPhone OS 8_0_2 like Mac OS X) AppleWebKit/600.1.4 (KHTML, like Gecko) Version/8.0 Mobile/12A405 Safari/600.1.4",

        };
    }
}
