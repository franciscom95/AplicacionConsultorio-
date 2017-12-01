package md50c7ddb093ad13fc24a156ca5a2f08146;


public class ListaPacientes
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Consultorio.Activitys.ListaPacientes, Consultorio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ListaPacientes.class, __md_methods);
	}


	public ListaPacientes () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ListaPacientes.class)
			mono.android.TypeManager.Activate ("Consultorio.Activitys.ListaPacientes, Consultorio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
