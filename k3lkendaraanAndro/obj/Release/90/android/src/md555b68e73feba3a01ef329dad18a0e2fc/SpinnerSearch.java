package md555b68e73feba3a01ef329dad18a0e2fc;


public class SpinnerSearch
	extends md555b68e73feba3a01ef329dad18a0e2fc.BaseSpinnerSearch
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SearchableSpinner.Droid.Controls.SpinnerSearch, SearchableSpinner.Droid", SpinnerSearch.class, __md_methods);
	}


	public SpinnerSearch (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SpinnerSearch.class)
			mono.android.TypeManager.Activate ("SearchableSpinner.Droid.Controls.SpinnerSearch, SearchableSpinner.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SpinnerSearch (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SpinnerSearch.class)
			mono.android.TypeManager.Activate ("SearchableSpinner.Droid.Controls.SpinnerSearch, SearchableSpinner.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SpinnerSearch (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SpinnerSearch.class)
			mono.android.TypeManager.Activate ("SearchableSpinner.Droid.Controls.SpinnerSearch, SearchableSpinner.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SpinnerSearch (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == SpinnerSearch.class)
			mono.android.TypeManager.Activate ("SearchableSpinner.Droid.Controls.SpinnerSearch, SearchableSpinner.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public SpinnerSearch (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3, android.content.res.Resources.Theme p4)
	{
		super (p0, p1, p2, p3, p4);
		if (getClass () == SpinnerSearch.class)
			mono.android.TypeManager.Activate ("SearchableSpinner.Droid.Controls.SpinnerSearch, SearchableSpinner.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib:Android.Content.Res.Resources+Theme, Mono.Android", this, new java.lang.Object[] { p0, p1, p2, p3, p4 });
	}


	public SpinnerSearch (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == SpinnerSearch.class)
			mono.android.TypeManager.Activate ("SearchableSpinner.Droid.Controls.SpinnerSearch, SearchableSpinner.Droid", "Android.Content.Context, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}

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
