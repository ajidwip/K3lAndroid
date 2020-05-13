package md5bc23ab7544bc4eb7d49b05e9f53bbbac;


public class login
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("k3lkendaraanAndro.login, k3lkendaraanAndro", login.class, __md_methods);
	}


	public login ()
	{
		super ();
		if (getClass () == login.class)
			mono.android.TypeManager.Activate ("k3lkendaraanAndro.login, k3lkendaraanAndro", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
