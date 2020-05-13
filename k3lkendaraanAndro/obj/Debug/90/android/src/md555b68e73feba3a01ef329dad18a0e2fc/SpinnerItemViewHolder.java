package md555b68e73feba3a01ef329dad18a0e2fc;


public class SpinnerItemViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SearchableSpinner.Droid.Controls.SpinnerItemViewHolder, SearchableSpinner.Droid", SpinnerItemViewHolder.class, __md_methods);
	}


	public SpinnerItemViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == SpinnerItemViewHolder.class)
			mono.android.TypeManager.Activate ("SearchableSpinner.Droid.Controls.SpinnerItemViewHolder, SearchableSpinner.Droid", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
