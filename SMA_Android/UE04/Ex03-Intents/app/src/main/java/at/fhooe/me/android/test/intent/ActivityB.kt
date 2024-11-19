package at.fhooe.me.android.test.intent

import android.app.Activity
import android.content.Intent
import android.net.Uri
import android.os.Bundle
import at.fhooe.me.android.test.intent.databinding.ActivityBBinding

class ActivityB : Activity() {

    lateinit var binding: ActivityBBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityBBinding.inflate(layoutInflater)
        setContentView(binding.root)

        val i: Intent = intent
        val content = i.getStringExtra(KEY_MESSAGE) ?: "undefined"
        binding.activityBTextviewDataContent.text = content

        binding.activityBButtonPhone.setOnClickListener {
            val i: Intent = Intent().apply {
                action = Intent.ACTION_DIAL
                data = Uri.parse("tel://123456")
            }
            startActivity(i)
        }
        binding.activityBButtonWeb.setOnClickListener {
            val i: Intent = Intent().apply {
                action = Intent.ACTION_VIEW
                data = Uri.parse("http://www.heise.de")
            }
            startActivity(i)
        }
        binding.activityBButtonMap.setOnClickListener {
//            Log.e(TAG, "ActivityB::activity_b_button_map::OnClickListener feature not yet supported")
            val i: Intent = Intent().apply {
                action = Intent.ACTION_VIEW
                data = Uri.parse("geo:48.368219,14.514365")
            }
            i.resolveActivity(packageManager)?.apply { startActivity(i) }
        }
    }

}