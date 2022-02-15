# unity-birds-studio


## change sprite for a 2d sprite
```c#
	GetComponent<SpriteRenderer>().sprite = m_newprite;
```

### working with normals to detect which direction a game object has been hit from
```c#
	private void OnCollisionEnter2D(Collision2D collision)
    {
		// if something falls on the game object from above
        // contacts is an array of objects hit by the object 
        // normal.y 	=> 0 means horizontal (from side), 
		//				=> -1 vertical (from above)
		//				=> +1 vertical (from below)
        if (collision.contacts[0].normal.y < -0.5)
        {
            // object was hit from above
        }
	}	
	
```


### on mouse drag to launch the player
```c#
 private void OnMouseDrag()
    {
		// getting current mouse position
        Vector3 m_mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 m_desiredPos = m_mousePos;
     
        
        // this is to make sure the player is not dragged too much at the beginning
        float m_distance = Vector2.Distance(m_desiredPos, m_startPos);
        if (m_distance > m_maxDragDistance)
        {
            Vector2 direction = m_desiredPos - m_startPos;
            direction.Normalize();

            // setting a point on the direction at a certain distance
            m_desiredPos = m_startPos + (direction * m_maxDragDistance);
        }

        // this is to prevent the bird to be dragged to the right
        if (m_desiredPos.x > m_startPos.x)
        {
            m_desiredPos.x = m_startPos.x;
        }

        m_rb.position = m_desiredPos;

    } // OnMouseDrag
```