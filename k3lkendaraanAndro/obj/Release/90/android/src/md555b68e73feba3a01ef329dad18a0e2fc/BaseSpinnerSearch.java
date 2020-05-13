package md555b68e73feba3a01ef329dad18a0e2fc;


public class BaseSpinnerSearch
	extends android.support.v7.widget.AppCompatSpinner
	implements
		mono.android.IGCUserPeer,
		android.content.DialogInterface.OnCancelListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_performClick:()Z:GetPerformClickHandler\n" +
			"n_onCancel:(Landroid/content/DialogInterface;)V:GetOnCancel_Landroid_content_DialogInterface_Handler:Android.Content.IDialogInterfaceOnCancelListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("SearchableSpinner.Droid.Controls.BaseSpinnerSearch, SearchableSpinner.Droid", BaseSpinnerSearch.class, __md_methods);
	}


	public BaseSpinnerSearch (android.content.Context p0)
	{
		super (p0);
		if (getClass () == BaseSpinnerSearch.class)
			mono.android.TypeManager.Activate ("SearchableSpinner.Droid.Controls.BaseSpinnerSearch, SearchableSpinner.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public BaseSpinnerSearch (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == BaseSpinnerSearch.class)
			mono.android.TypeManager.Activate ("SearchableSpinner.Droid.Controls.BaseSpinnerSearch, SearchableSpinner.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public BaseSpinnerSearch (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == BaseSpinnerSearch.class)
			mono.android.TypeManager.Activate ("SearchableSpinner.Droid.Controls.BaseSpinnerSearch, SearchableSpinner.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public BaseSpinnerSearch (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == BaseSpinnerSearch.class)
			mono.android.TypeManager.Activate ("SearchableSpinner.Droid.Controls.BaseSpinnerSearch, SearchableSpinner.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public BaseSpinnerSearch (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3, android.content.res.Resources.Theme p4)
	{
		super (p0, p1, p2, p3, p4);
		if (getClass () == BaseSpinnerSearch.class)
			mono.android.TypeManager.Activate ("SearchableSpinner.Droid.Controls.BaseSpinnerSearch, SearchableSpinner.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib:Android.Content.Res.Resources+Theme, Mono.Android", this, new java.lang.Object[] { p0, p1, p2, p3, p4 });
	}


	public BaseSpinnerSearch (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == BaseSpinnerSearch.class)
			mono.android.TypeManager.Activate ("SearchableSpinner.Droid.Controls.BaseSpinnerSearch, SearchableSpinner.Droid", "Android.Content.Context, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public boolean performClick ()
	{
		return n_performClick ();
	}

	private native boolean n_performClick ();


	public void onCancel (android.content.DialogInterface p0)
	{
		n_onCancel (p0);
	}

	private native void n_onCancel (android.content.DialogInterface p0);

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
