package md5fef4d7baabe4e5cb77761ace866b8793;


public class TabbedPageCustomRenderer
	extends md5b60ffeb829f638581ab2bb9b1a7f4f3f.TabbedRenderer
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onInterceptTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnInterceptTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("HSE_APP.Droid.TabbedPageCustomRenderer, TabbedPageDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TabbedPageCustomRenderer.class, __md_methods);
	}


	public TabbedPageCustomRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == TabbedPageCustomRenderer.class)
			mono.android.TypeManager.Activate ("HSE_APP.Droid.TabbedPageCustomRenderer, TabbedPageDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public TabbedPageCustomRenderer (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == TabbedPageCustomRenderer.class)
			mono.android.TypeManager.Activate ("HSE_APP.Droid.TabbedPageCustomRenderer, TabbedPageDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public TabbedPageCustomRenderer (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == TabbedPageCustomRenderer.class)
			mono.android.TypeManager.Activate ("HSE_APP.Droid.TabbedPageCustomRenderer, TabbedPageDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public boolean onInterceptTouchEvent (android.view.MotionEvent p0)
	{
		return n_onInterceptTouchEvent (p0);
	}

	private native boolean n_onInterceptTouchEvent (android.view.MotionEvent p0);

	java.util.ArrayList refList;
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
