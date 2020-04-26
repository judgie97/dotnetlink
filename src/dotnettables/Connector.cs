using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace dotnettables
{
    public static class Connector
    {
        private static string CallNFT(string arguments, string? stdin = null)
        {
            var startInfo = new ProcessStartInfo("nft");
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;

            var process = new Process();
            startInfo.Arguments = arguments;
            startInfo.RedirectStandardOutput = true;
            process.StartInfo = startInfo;
            process.Start();

            if (stdin != null)
            {
                var streamWriter = process.StandardInput;
                streamWriter.WriteLine(stdin);
                streamWriter.Close();
            }

            process.WaitForExit();

            StringBuilder stringBuilder = new StringBuilder();
            while (!process.StandardOutput.EndOfStream)
            {
                stringBuilder.AppendLine(process.StandardOutput.ReadLine());
            }

            return stringBuilder.ToString();
        }

        //nft -j list ruleset
        public static Firewall GetFirewall()
        {
            string nftOutput = CallNFT("-j list ruleset");
            Firewall firewall = JsonConvert.DeserializeObject<Firewall>(nftOutput);
            return firewall;
        }

        //nft -j list chains
        public static Firewall GetFirewallChains()
        {
            string nftOutput = CallNFT("-j list chains");
            Firewall firewall = JsonConvert.DeserializeObject<Firewall>(nftOutput);
            return firewall;
        }

        //nft -j list tables
        public static Firewall GetFirewallTables()
        {
            string nftOutput = CallNFT("-j list tables");
            Firewall firewall = JsonConvert.DeserializeObject<Firewall>(nftOutput);
            return firewall;
        }

        //nft -j -f -
        public static void SetFirewall(Firewall firewall)
        {
            CallNFT("-j -f -", JsonConvert.SerializeObject(firewall));
        }

        //nft flush ruleset
        public static void ClearAll()
        {
            CallNFT("flush ruleset");
        }
    }
}