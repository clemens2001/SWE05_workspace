package at.fhooe.me.android.test.intent

import android.app.Activity
import android.content.ComponentName
import android.content.Intent
import android.os.Bundle
import at.fhooe.me.android.test.intent.databinding.ActivityMainBinding
import java.util.*

const val KEY_MESSAGE: String = "message-key"
const val TAG: String = "Intent-Test"

class MainActivity : Activity() {

    lateinit var binding: ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

//        val i: Intent = Intent(this, ActivityA::class.java)

        binding.mainButtonA.setOnClickListener { view ->
            val intentA: Intent = Intent(this, ActivityA::class.java)
            startActivity(intentA)
        }
        binding.mainButtonB.setOnClickListener { view ->
            val intentB: Intent = Intent(this, ActivityB::class.java).apply {
                action = Intent.ACTION_SEND
                type = "text/plain"

                val now: Calendar = Calendar.getInstance()
                putExtra(KEY_MESSAGE, "${now.time.toString()}:\n a message in the bottle")
            }
            startActivity(intentB)
        }
        binding.mainButtonEnd.setOnClickListener {
            finish()
        }
    }
}