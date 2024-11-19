package at.fhooe.me.android.test.intent

import android.app.Activity
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import at.fhooe.me.android.test.intent.databinding.ActivityABinding


class ActivityA : Activity() {

    lateinit var binding: ActivityABinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityABinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.activityAButtonMain.setOnClickListener { _view ->
            val i: Intent = Intent(this, MainActivity::class.java).apply {
                flags = Intent.FLAG_ACTIVITY_CLEAR_TOP
            }
            startActivity(i)
        }

        binding.activityAButtonB.setOnClickListener {
            val i = Intent(this, ActivityB::class.java)
            startActivity(i)
        }
    }
}