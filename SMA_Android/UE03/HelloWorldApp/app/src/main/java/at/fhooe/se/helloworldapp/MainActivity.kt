package at.fhooe.se.helloworldapp

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.Button
import androidx.appcompat.app.AppCompatActivity
import at.fhooe.se.helloworldapp.databinding.ActivityMainBinding
import at.fhooe.se.helloworldapp.databinding.ActivityMainDeepBinding

private const val TAG = "MainActivity"

class MainActivity : AppCompatActivity(), View.OnClickListener {
    private lateinit var binding: ActivityMainDeepBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main_deep)
/*        val button: Button = findViewById(R.id.button_01)
        button.setOnClickListener {
            startActivity(Intent(this, OverviewActivity::class.java))
        }*/
/*

        binding = ActivityMainDeepBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.button01.setOnClickListener {
            startActivity(Intent(this, OverviewActivity::class.java))
        }
*/
        binding = ActivityMainDeepBinding.inflate(layoutInflater)
        setContentView(binding.root)

        val listener: View.OnClickListener = MyOnClickListener()
        binding.button01.setOnClickListener(this)
        binding.button02.setOnClickListener(this)
        binding.button03.setOnClickListener(listener)
        binding.button04.setOnClickListener(listener)
        binding.button05.setOnClickListener({ foo ->
            Log.d(TAG, "MainActivity anonomous onClickListener of Button 05")
        })
        binding.button06.setOnClickListener({ _v ->
            Log.d(TAG, "MainActivity anonomous onClickListener of Button 06")
        })


        Log.d(TAG, "onCreate() called")
    }

    class MyOnClickListener : View.OnClickListener {
        override fun onClick(_v: View?) {
            when (_v?.id) {
                R.id.button_03 -> {
                    Log.d(TAG, "MyOnClickListener::onClick Button 03 clicked")
                }

                R.id.button_04 -> {
                    Log.d(TAG, "MyOnClickListener::onClick Button 04 clicked")
                }

                else -> {
                    Log.d(TAG, "MyOnClickListener::onClick unhandled onClick id encountered")
                }
            }
        }
    }

    override fun onClick(_v: View?) {
        when(_v?.id) {
            R.id.button_01 -> {
                Log.d(TAG, "MainActivity::onClick Button 01 clicked")
            }
            R.id.button_02 -> {
                Log.d(TAG, "MainActivity::onClick Button 02 clicked")
            }
            else -> {
                Log.d(TAG, "MainActivity::onClick unhandled onClick id encountered")
            }
        }
    }



    //region Lifecycle methods
    override fun onStart() {
        super.onStart();

        Log.e(TAG, "onStart() called")
    }

    override fun onResume() {
        super.onResume();

        Log.i(TAG, "onResume() called")
    }

    override fun onPause() {
        super.onPause();

        Log.w(TAG, "onPause() called")
    }

    override fun onStop() {
        super.onStop();

        Log.d(TAG, "onStop() called")
    }

    override fun onDestroy() {
        super.onDestroy();

        Log.d(TAG, "onDestroy() called")
    }

    override fun onRestart() {
        super.onRestart();

        Log.d(TAG, "onRestart() called")
    }
    //endregion


}