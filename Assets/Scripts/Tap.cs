using UnityEngine;
using UnityEngine.SceneManagement;

public class Tap : MonoBehaviour {

	[SerializeField] private float radius;
	[SerializeField] private float force;
	[SerializeField] private LayerMask layerMask;
	public bool gameOver;
	public GameObject restart;
	public Pin pin_class;

    void Explosion2D(Vector3 position)
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius, layerMask);

		foreach(Collider2D hit in colliders)
		{
			if(hit.attachedRigidbody != null)
			{
				Vector3 direction = hit.transform.position - position;
				direction.z = 0;
				hit.attachedRigidbody.AddForce(direction.normalized * force);
				pin_class.flip = true;
			}
		}
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && gameOver == false)
		{
			Explosion2D(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
		if (gameOver)
		{
			restart.SetActive(true);
		}
        else
        {
			restart.SetActive(false);
        }
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}



}
