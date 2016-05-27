package md5fef4d7baabe4e5cb77761ace866b8793;


public class GesutreListener
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onFling:(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z:GetOnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FFHandler\n" +
			"";
		mono.android.Runtime.register ("HSE_APP.Droid.GesutreListener, TabbedPageDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GesutreListener.class, __md_methods);
	}


	public GesutreListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == GesutreListener.class)
			mono.android.TypeManager.Activate ("HSE_APP.Droid.GesutreListener, TabbedPageDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean onFling (android.view.MotionEvent p0, android.view.MotionEvent p1, float p2, float p3)
	{
		return n_onFling (p0, p1, p2, p3);
	}

	private native boolean n_onFling (android.view.MotionEvent p0, android.view.MotionEvent p1, float p2, float p3);

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
