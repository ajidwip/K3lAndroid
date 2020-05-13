package md5bc23ab7544bc4eb7d49b05e9f53bbbac;


public class JSInterface2
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onShare:(Ljava/lang/String;Ljava/lang/String;)V:__export__\n" +
			"";
		mono.android.Runtime.register ("k3lkendaraanAndro.JSInterface2, k3lkendaraanAndro", JSInterface2.class, __md_methods);
	}


	public JSInterface2 ()
	{
		super ();
		if (getClass () == JSInterface2.class)
			mono.android.TypeManager.Activate ("k3lkendaraanAndro.JSInterface2, k3lkendaraanAndro", "", this, new java.lang.Object[] {  });
	}

	public JSInterface2 (android.content.Context p0)
	{
		super ();
		if (getClass () == JSInterface2.class)
			mono.android.TypeManager.Activate ("k3lkendaraanAndro.JSInterface2, k3lkendaraanAndro", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	@android.webkit.JavascriptInterface

	public void onShare (java.lang.String p0, java.lang.String p1)
	{
		n_onShare (p0, p1);
	}

	private native void n_onShare (java.lang.String p0, java.lang.String p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
